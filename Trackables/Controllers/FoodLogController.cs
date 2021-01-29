using AutoMapper;
using Trackables.Domain;
using Trackables.Models;
using Trackables.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Trackables.Controllers
{
    [Authorize]
    public class FoodLogController : Controller
    {
        private readonly IServingServices _servingServices;
        private readonly IProductServices _productServices;
        private readonly IMealServices _mealServices;

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


        public FoodLogController()
        { }

        public FoodLogController(IServingServices servingServices, IProductServices productServices, IMealServices mealServices)
        {
            _productServices = productServices;
            _servingServices = servingServices;
            _mealServices = mealServices;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult RefreshServingTable(DateTime date)
        {
            var viewModel = GetServingTableViewModel(date);

            return PartialView("ServingTable", viewModel);
        }

        public ActionResult RefreshMealsTable(DateTime date)
        {
            var viewModel = GetMealsTableViewModel(date);

            return PartialView("MealsTable", viewModel);
        }

        /// <summary>
        /// This is called when you select a product from the autocomplete list.
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public ActionResult SelectFood(string Code, DateTime date)
        {
            _servingServices.InsertServing(Code, 0, date, UserId);

            var viewModel = GetServingTableViewModel(date);

            return PartialView("ServingTable", viewModel);
        }



        public ActionResult Save(int id, int quantity, DateTime date)
        {
            _servingServices.UpdateServing(id, quantity);

            var viewModel = GetServingTableViewModel(date);

            return PartialView("ServingTable", viewModel);
        }



        public ActionResult UseMeal(int id, DateTime date)
        {
            Meal meal = _mealServices.GetMeal(UserId, id);

            foreach (Ingredient ingredient in meal.Ingredients)
            {
                _servingServices.InsertServing(ingredient.Code, ingredient.Quantity, date, UserId);
            }

            var viewModel = GetServingTableViewModel(date);

            return PartialView("ServingTable", viewModel);
        }


        public ActionResult Delete(int id, DateTime date)
        {
            _servingServices.DeleteServing(id);

            var viewModel = GetServingTableViewModel(date);

            return PartialView("ServingTable", viewModel);
        }



        private ServingTableViewModel GetServingTableViewModel(DateTime date)
        {
            List<Serving> servings = _servingServices.GetServings(date, UserId).OrderByDescending(x => x.Id).ToList();
            List<ServingViewModel> servingViewModel = Mapper.Map<List<Serving>, List<ServingViewModel>>(servings);

            var viewModel = new ServingTableViewModel()
            {
                Servings = servingViewModel
            };

            return viewModel;
        }



        private MealsTableViewModel GetMealsTableViewModel(DateTime date)
        {
            List<Meal> meals = _mealServices.GetMeals(UserId).OrderBy(x => x.Name).ToList();
            var mealsViewModel = Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(meals);

            var viewModel = new MealsTableViewModel()
            {
                Meals = mealsViewModel
            };

            return viewModel;
        }


        ///// <summary>
        ///// When we favourite something, we also want to save it - otherwise it is possible to edit a quantity, then
        ///// update the Favourites table without updating the Servings.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="quantity"></param>
        ///// <returns></returns>
        //public ActionResult Favourite(int id, int quantity)
        //{
        //    User user = _userServices.GetUser(User.Identity.Name);

        //    _servingServices.UpdateServing(id, quantity);
        //    _servingServices.MergeFavourite(user.Id, id, quantity);

        //    return RedirectToAction("Index");
        //}


        //public ActionResult UseFavourite(string Code, DateTime date)
        //{
        //    User user = _userServices.GetUser(User.Identity.Name);

        //    Favourite favourite = _servingServices.GetFavourites(user.Id).Where(f => f.Code == Code).First();
        //    _servingServices.InsertServing(Code, favourite.Quantity, date, user.Id);

        //    return RedirectToAction("Index");
        //}


        //public ActionResult DeleteFavourite(string Code)
        //{
        //    User user = _userServices.GetUser(User.Identity.Name);

        //    _servingServices.DeleteFavourite(user.Id, Code);

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Refresh(DateTime date)
        //{
        //    //User user = _userServices.GetUser(User.Identity.Name);
        //    User user = new User { Id = 1 };

        //    // Favourites
        //    List<Favourite> favourites = _servingServices.GetFavourites(user.Id).OrderBy(x => x.Name).ToList();
        //    var favouritesViewModel = Mapper.Map<IEnumerable<Favourite>, IEnumerable<FavouriteViewModel>>(favourites);

        //    // Food items
        //    List<Serving> servings = _servingServices.GetServings(date, user.Id).OrderByDescending(x => x.Id).ToList();
        //    List<Product> products = _productServices.GetProducts(servings).ToList();
        //    var servingsViewModel = CalculateCaloriesByServing(servings, products);

        //    // Meals
        //    List<Meal> meals = _mealServices.GetMeals(user.Id).OrderBy(x => x.Name).ToList();
        //    var mealsViewModel = Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(meals);


        //    var viewModel = new WeightFirstServingListViewModel()
        //    {
        //        Favourites = favouritesViewModel,
        //        Servings = servingsViewModel,
        //        Meals = mealsViewModel,
        //        TotalCalories = CalculateTotalCalories(servingsViewModel)
        //    };

        //    return Json(viewModel, JsonRequestBehavior.AllowGet);
        //}


        //private decimal CalculateTotalCalories(List<WeightFirstServingViewModel> servingsViewModel)
        //{
        //    decimal total = 0m;

        //    foreach (var item in servingsViewModel)
        //    {
        //        total += item.Calories;
        //    }

        //    return total;
        //}

        //private List<WeightFirstServingViewModel> CalculateCaloriesByServing(List<Serving> servings, List<Product> products)
        //{
        //    List<WeightFirstServingViewModel> viewModel = Mapper.Map<List<Serving>, List<WeightFirstServingViewModel>>(servings);

        //    foreach (var item in viewModel)
        //    {
        //        Product product = products.Where(p => p.Code == item.Code).First();
        //        decimal calories = product.ProductMacronutrients.Quantity("Calories");

        //        item.Calories = Convert.ToInt32(Math.Round(item.Quantity * (calories / 100), 0));
        //    }

        //    return viewModel;
        //}


    }
}