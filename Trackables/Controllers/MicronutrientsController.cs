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
    public class MicronutrientsController : Controller
    {
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

        public MicronutrientsController()
        { }

        public MicronutrientsController(IChartServices chartServices)
        {
            _chartServices = chartServices;
        }

        public ActionResult Index()
        {
            return View("Index", new MicronutrientsViewModel());
        }

        public ActionResult RefreshBarChart(DateTime start, DateTime end, string nutrient)
        {
            var viewModel = new ChartViewModel();

            viewModel.BarNames = _chartServices.GetProductNames(start, end, UserId);
            viewModel.ChartTitle = _chartServices.GetMicronutrientTitle(nutrient);
            viewModel.BarData = _chartServices.CalculateMicronutrientByProduct(start, end, new List<string> { nutrient }, UserId);
            CalculateTotals(ref viewModel);
            CalculateRDA(ref viewModel, nutrient);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RefreshLineChart(DateTime start, DateTime end, string nutrient)
        {
            var viewModel = new ChartViewModel();

            viewModel.BarNames = _chartServices.GetDates(start, end, UserId);
            viewModel.ChartTitle = _chartServices.GetMicronutrientTitle(nutrient);
            viewModel.BarData = _chartServices.CalculateMicronutrientByDay(start, end, new List<string> { nutrient }, UserId);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        private void CalculateTotals(ref ChartViewModel viewModel)
        {
            foreach (var list in viewModel.BarData)
            {
                var total = list.Sum();
                list.Add(total);
            }

            viewModel.BarNames.Add("Total");
        }

        private void CalculateRDA(ref ChartViewModel viewModel, string nutrient)
        {
            foreach (var list in viewModel.BarData)
            {
                list.Add(Micronutrients.Nutrient(nutrient).RDA);
            }

            viewModel.BarNames.Add("RDA");
        }

    }
}