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
    public class MacronutrientsController : Controller
    {
        private readonly IFoodItemServices _foodItemServices;
        private readonly IProductServices _productServices;
        private readonly IChartServices _chartServices;
        private readonly IUserServices _userServices;

        public MacronutrientsController()
        { }

        public MacronutrientsController(IChartServices chartServices, IFoodItemServices foodItemServices, IProductServices productServices, IUserServices userServices)
        {
            _productServices = productServices;
            _foodItemServices = foodItemServices;
            _chartServices = chartServices;
            _userServices = userServices;
        }

        public ActionResult Index()
        {
            return View("Index", new MacronutrientsViewModel());
        }

        public ActionResult RefreshBarChart(DateTime start, DateTime end, string nutrient)
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            List<Day> days = _foodItemServices.GetDays(start, end, user.Id).ToList();
            List<Product> products = _productServices.GetProducts(days).ToList();
            var viewModel = new ChartViewModel();

            if (nutrient.ToLower() == "macronutrient ratios")
            {
                viewModel.BarNames = _chartServices.GetDates(days);
                viewModel.ChartTitle = _chartServices.GetMacronutrientRatioCategories();
                viewModel.BarData = _chartServices.CalculateMacronutrientRatioData(days, products);
            }
            else if (nutrient.ToLower() == "alcohol")
            {
                viewModel.BarNames = _chartServices.GetBarNames(days);
                viewModel.ChartTitle = _chartServices.GetMacronutrientTitle(nutrient);
                viewModel.BarData = _chartServices.CalculateAlcoholByProduct(days, products);
                viewModel.BarNames.Add("RDA");
                viewModel.BarData.First().Add(_chartServices.GetMacronutrientRDA(nutrient));
            }
            else
            {
                viewModel.BarNames = _chartServices.GetBarNames(days);
                viewModel.ChartTitle = _chartServices.GetMacronutrientTitle(nutrient);
                viewModel.BarData = _chartServices.CalculateMacroNutrientByProduct(days, products, nutrient);
                viewModel.BarNames.Add("RDA");
                viewModel.BarData.First().Add(_chartServices.GetMacronutrientRDA(nutrient));
            }


            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RefreshLineChart(DateTime start, DateTime end, string nutrient)
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            List<Day> days = _foodItemServices.GetDays(start, end, user.Id).ToList();
            List<Product> products = _productServices.GetProducts(days).ToList();
            var viewModel = new ChartViewModel();

            if (nutrient.ToLower() == "macronutrient ratios")
            {
                viewModel.BarNames = _chartServices.GetDates(days);
                viewModel.ChartTitle = _chartServices.GetMacronutrientRatioCategories();
                viewModel.BarData = _chartServices.CalculateMacronutrientRatioData(days, products);

            }
            else if (nutrient.ToLower() == "alcohol")
            {
                viewModel.BarNames = _chartServices.GetDates(days);
                viewModel.ChartTitle = _chartServices.GetMacronutrientTitle(nutrient);
                viewModel.BarData = _chartServices.CalculateAlcoholByDay(days, products);
            }
            else
            {
                viewModel.BarNames = _chartServices.GetDates(days);
                viewModel.ChartTitle = _chartServices.GetMacronutrientTitle(nutrient);
                viewModel.BarData = _chartServices.CalculateMacroNutrientByDay(days, products, nutrient);
            }
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

    }
}