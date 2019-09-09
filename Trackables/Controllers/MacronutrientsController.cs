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
    public class MacronutrientsController : Controller
    {
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
            return View("Index", new MacronutrientsDropDownListViewModel());
        }

        public ActionResult RefreshBarChart(DateTime start, DateTime end, string nutrient)
        {
            List<Day> days = _foodItemServices.GetDays(start, end, UserId).ToList();
            List<Product> products = _productServices.GetProducts(UserId, days).ToList();
            var viewModel = new BarChartViewModel();

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
                //viewModel.BarNames.Add("RDA");
                //viewModel.BarData.Add(_chartServices.GetMacronutrientRDA(nutrient));
            }
            else
            {
                viewModel.BarNames = _chartServices.GetBarNames(days);
                viewModel.ChartTitle = _chartServices.GetMacronutrientTitle(nutrient);
            //    viewModel.BarData = GetDummyLists();
                viewModel.BarData = _chartServices.CalculateMacronutrientByProduct(start, end, nutrient, UserId);
                //viewModel.BarData = _chartServices.CalculateMacroNutrientByProduct(days, products, nutrient);
                //                viewModel.BarNames.Add("RDA");
                //              viewModel.BarData.Add(_chartServices.GetMacronutrientRDA(nutrient));
            }

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        private List<List<decimal?>> GetDummyLists()
        {
            //return new List<List<decimal?>>
            //{
            //    new List<decimal?>{33m},
            //    new List<decimal?>{44m},
            //    new List<decimal?>{3m},
            //    new List<decimal?>{67m},
            //    new List<decimal?>{31m}
            //};

            return new List<List<decimal?>>
            {
                new List<decimal?>{33m,44m,3m,67m,31m },
                new List<decimal?>{3m,4m,73m,7m,1m }
            };
        }

        public ActionResult RefreshLineChart(DateTime start, DateTime end, string nutrient)
        {
            List<Day> days = _foodItemServices.GetDays(start, end, UserId).ToList();
            List<Product> products = _productServices.GetProducts(UserId, days).ToList();
            var viewModel = new LineChartViewModel();

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
                viewModel.BarData = _chartServices.CalculateMacronutrientByDay(start, end, nutrient, UserId);

                //var temp = new List<List<decimal?>>();
                //temp.Add(_chartServices.CalculateMacroNutrientByDay(days, products, nutrient));
                //viewModel.BarData = temp;
            }
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

    }
}