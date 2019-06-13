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

        public MicronutrientsController()
        { }

        public MicronutrientsController(IChartServices chartServices, IFoodItemServices foodItemServices, IProductServices productServices, IUserServices userServices)
        {
            _productServices = productServices;
            _foodItemServices = foodItemServices;
            _chartServices = chartServices;
            _userServices = userServices;
        }

        public ActionResult Index()
        {
            return View("Index", new MicronutrientsViewModel());
        }

        public ActionResult RefreshBarChart(DateTime start, DateTime end, string nutrient)
        {
            List<Day> days = _foodItemServices.GetDays(start, end, UserId).ToList();
            List<Product> products = _productServices.GetProducts(UserId, days).ToList();
            var viewModel = new ChartViewModel();

            viewModel.BarNames = _chartServices.GetBarNames(days);
            viewModel.ChartTitle = _chartServices.GetMicronutrientTitle(nutrient);
            viewModel.BarData = _chartServices.CalculateMicroNutrientByProduct(days, products, nutrient);

            viewModel.BarNames.Add("RDA");
            viewModel.BarData.First().Add(_chartServices.GetMicronutrientRDA(nutrient));

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RefreshLineChart(DateTime start, DateTime end, string nutrient)
        {
            List<Day> days = _foodItemServices.GetDays(start, end, UserId).ToList();
            List<Product> products = _productServices.GetProducts(UserId, days).ToList();
            var viewModel = new ChartViewModel();

            viewModel.BarNames = _chartServices.GetDates(days);
            viewModel.ChartTitle = _chartServices.GetMicronutrientTitle(nutrient);
            viewModel.BarData = _chartServices.CalculateMicroNutrientByDay(days, products, nutrient);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

    }
}