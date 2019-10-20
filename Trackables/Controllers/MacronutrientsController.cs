using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Trackables.Models;
using Trackables.Services.Abstract;


namespace Trackables.Controllers
{
    [Authorize]
    public class MacronutrientsController : Controller
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

        public MacronutrientsController()
        { }

        public MacronutrientsController(IChartServices chartServices)
        {
            _chartServices = chartServices;
        }

        public ActionResult Index()
        {
            return View("Index", new MacronutrientsDropDownListViewModel());
        }

        public ActionResult RefreshBarChart(DateTime start, DateTime end, string nutrient)
        {
            var viewModel = new BarChartViewModel();
            List<string> categories;
            List<string> names;
            List<List<decimal?>> data;

            if (nutrient.ToLower() == "macronutrient ratios")
            {
                categories = new List<string> { string.Empty };
                names = _chartServices.GetMacronutrientRatioCategories();
                data = _chartServices.CalculateMacronutrientRatioData(start, end, UserId);
            }
            else
            {
                categories = _chartServices.GetProductNames(start, end, UserId);
                names = _chartServices.GetMacronutrientTitle(nutrient);
                data = _chartServices.CalculateMacronutrientByProduct(start, end, new List<string> { nutrient }, UserId);

                //CalculateTotals(ref viewModel);
                //CalculateRDA(ref viewModel, nutrient);
            }

            viewModel.Categories = categories;
            viewModel.MapToSeries(data, names);


            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RefreshLineChart(DateTime start, DateTime end, string nutrient)
        {
            var viewModel = new LineChartViewModel();
            List<string> categories;
            List<string> names;
            List<List<decimal?>> data;

            if (nutrient.ToLower() == "macronutrient ratios")
            {
                categories = _chartServices.GetDates(start, end, UserId);
                names = _chartServices.GetMacronutrientRatioCategories();
                data = _chartServices.CalculateMacronutrientRatioData(start, end, UserId);
            }
            else
            {
                categories = _chartServices.GetDates(start, end, UserId);
                names = _chartServices.GetMacronutrientTitle(nutrient);
                data = _chartServices.CalculateMacronutrientByDay(start, end, new List<string> { nutrient }, UserId);
            }

            viewModel.Categories = categories;
            viewModel.MapToSeries(data, names);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        //private void CalculateTotals(ref BarChartViewModel viewModel)
        //{
        //    foreach (var series in viewModel.Series)
        //    {
        //        var total = series.Data.Sum();
        //        series.Data.Add(total);
        //    }

        //    viewModel.Categories.Add("Total");
        //}

        //private void CalculateRDA(ref BarChartViewModel viewModel, string nutrient)
        //{
        //    foreach (var series in viewModel.Series)
        //    {
        //        series.Data.Add(Macronutrients.Nutrient(nutrient).RDA);
        //    }

        //    viewModel.Categories.Add("RDA");
        //}

        //private void CalculateTotals(ref ChartViewModel viewModel)
        //{
        //    foreach (var list in viewModel.BarData)
        //    {
        //        var total = list.Sum();
        //        list.Add(total);
        //    }

        //    viewModel.BarNames.Add("Total");
        //}

        //private void CalculateRDA(ref ChartViewModel viewModel, string nutrient)
        //{
        //    foreach (var list in viewModel.BarData)
        //    {
        //        list.Add(Macronutrients.Nutrient(nutrient).RDA);
        //    }

        //    viewModel.BarNames.Add("RDA");
        //}

    }
}
