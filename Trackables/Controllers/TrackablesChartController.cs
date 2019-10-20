using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trackables.Domain;
using Trackables.Models;
using Trackables.Services.Abstract;

namespace Trackables.Controllers
{
    [Authorize]
    public class TrackablesChartController : Controller
    {
        private readonly IHighchartsServices _highchartsServices;
        private readonly ITrackablesServices _trackablesServices;
        private readonly IChartServices _chartServices;

        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public string UserId
        {
            get
            {
                return UserManager.FindById(User.Identity.GetUserId()).Id;
            }
        }

        public TrackablesChartController()
        { }

        public TrackablesChartController(ITrackablesServices trackablesServices, IChartServices chartServices, IHighchartsServices highchartsServices)
        {
            _highchartsServices = highchartsServices;
            _trackablesServices = trackablesServices;
            _chartServices = chartServices;
        }

        public ActionResult Index()
        {
            return View("Index", new ChartTypeDropDownListViewModel());
        }

        public ActionResult RefreshTrackableItemsList()
        {
            var viewModel = GetTrackablesModel();

            return PartialView("TrackablesList", viewModel);
        }

        public ActionResult RefreshMacronutrientsList()
        {
            var viewModel = GetMacronutrientsModel();

            return PartialView("MacronutrientsList", viewModel);
        }

        public ActionResult RefreshChart(DateTime start, DateTime end, TrackablesChartIdentifiers selectedIds)
        {
            var viewModel = new HighchartsViewModel();

            if (selectedIds.Trackables != null)
            {
                var SeriesTrackables = _highchartsServices.GetSeries(start, end, selectedIds.Trackables).ToList();
                viewModel.Series.AddRange(SeriesTrackables);
            }

            if (selectedIds.Macronutrients != null)
            {
                var SeriesMacronutrients = _chartServices.GetSeries(start, end, selectedIds.Macronutrients, UserId).ToList();
                viewModel.Series.AddRange(SeriesMacronutrients);
            }

            viewModel.Categories = _chartServices.GetDates(start, end, UserId);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        private TrackablesViewModel GetTrackablesModel()
        {
            List<Trackable> trackables = _trackablesServices.GetTrackables(UserId).OrderBy(x => x.Name).ToList();

            var viewModel = new TrackablesViewModel()
            {
                Trackables = trackables
            };

            return viewModel;
        }

        private MacronutrientsViewModel GetMacronutrientsModel()
        {
            var viewModel = new MacronutrientsViewModel()
            {
                Macronutrients = Macronutrients.Nutrients
            };

            return viewModel;
        }
    }
}