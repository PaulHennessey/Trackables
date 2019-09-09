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
        private readonly ITrackableItemServices _trackableItemServices;
        private readonly ITrackablesServices _trackablesServices;
        private readonly IFoodItemServices _foodItemServices;
        private readonly IProductServices _productServices;
        private readonly IChartServices _chartServices;
        private readonly IUserServices _userServices;

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

        public TrackablesChartController(ITrackableItemServices trackableItemServices, ITrackablesServices trackablesServices, IChartServices chartServices, IFoodItemServices foodItemServices, IProductServices productServices, IUserServices userServices)
        {
            _trackableItemServices = trackableItemServices;
            _trackablesServices = trackablesServices;
            _productServices = productServices;
            _foodItemServices = foodItemServices;
            _chartServices = chartServices;
            _userServices = userServices;
        }

        public ActionResult Index()
        {
            return View("Index");
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


        // VM:
        //            List<ChartItemList>:
        //ChartItemList:
        //            List<ChartItem>
        //            Name:
        //ChartItem:
        //        Date:
        //        Quantity:

        /// <summary>
        /// Note that the two methods are identical right now?
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="selectedIds"></param>
        /// <returns></returns>
        public ActionResult RefreshBarChart(DateTime start, DateTime end, TrackablesChartIdentifiers selectedIds)
        {
            // Might be nice to fix this null binding issue
            // https://lostechies.com/jimmybogard/2013/11/07/null-collectionsarrays-from-mvc-model-binding/

            List<ChartItemList> lists = _trackableItemServices.GetTrackableChartItems(start, end, selectedIds.Trackables).ToList();
            var viewModel = new LineChartViewModel();

            foreach (var list in lists)
            {
                viewModel.ChartTitle.Add(list.Name);
            }

            // Map the dates to the BarNames. You only need to do that once
            // because they are the same on every list. 
            foreach (var item in lists.First().ChartItems)
            {
                viewModel.BarNames.Add(item.Date.ToShortDateString());
            }

            // Map the quantities to the BarData.
            foreach (var list in lists)
            {
                var data = new List<decimal?>();

                foreach (var item in list.ChartItems)
                {
                    data.Add(item.Quantity);
                }

                viewModel.BarData.Add(data);
            }

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RefreshLineChart(DateTime start, DateTime end, TrackablesChartIdentifiers selectedIds)
        {
            var viewModel = new LineChartViewModel();

            List<ChartItemList> lists = _trackableItemServices.GetTrackableChartItems(start, end, selectedIds.Trackables).ToList();
            foreach (var list in lists)
            {
                viewModel.ChartTitle.Add(list.Name);
            }

            // Map the dates to the BarNames. You only need to do that once
            // because they are the same on every list. 
            foreach (var item in lists.First().ChartItems)
            {
                viewModel.BarNames.Add(item.Date.ToShortDateString());
            }

            // Map the quantities to the BarData.
            foreach (var list in lists)
            {
                var data = new List<decimal?>();

                foreach (var item in list.ChartItems)
                {
                    data.Add(item.Quantity);
                }

                viewModel.BarData.Add(data);
            }

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }



    }
}