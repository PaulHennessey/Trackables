using AutoMapper;
using Trackables.Domain;
using Trackables.Models;
using Trackables.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trackables.Controllers
{
    public class FoodLogController : Controller
    {
        private readonly IFoodItemServices _foodItemServices;
        private readonly IProductServices _productServices;
        private readonly IMealServices _mealServices;
        private readonly IUserServices _userServices;

        public FoodLogController()
        { }

        public FoodLogController(IFoodItemServices foodItemServices, IProductServices productServices, IUserServices userServices, IMealServices mealServices)
        {
            _productServices = productServices;
            _foodItemServices = foodItemServices;
            _userServices = userServices;
            _mealServices = mealServices;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult RefreshFoodItemTable(DateTime date)
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            var viewModel = GetFoodItemTableViewModel(user, date);

            return PartialView("FoodItemTable", viewModel);
        }

        public ActionResult RefreshMealsTable(DateTime date)
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            var viewModel = GetMealsTableViewModel(user, date);

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
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            _foodItemServices.InsertFoodItem(Code, 0, date, user.Id);

            var viewModel = GetFoodItemTableViewModel(user, date);

            return PartialView("FoodItemTable", viewModel);
        }



        public ActionResult Save(int id, int quantity, DateTime date)
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            _foodItemServices.UpdateFoodItem(id, quantity);

            var viewModel = GetFoodItemTableViewModel(user, date);

            return PartialView("FoodItemTable", viewModel);
        }



        public ActionResult UseMeal(int id, DateTime date)
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            Meal meal = _mealServices.GetMeal(id);

            foreach (Ingredient ingredient in meal.Ingredients)
            {
                _foodItemServices.InsertFoodItem(ingredient.Code, ingredient.Quantity, date, user.Id);
            }

            var viewModel = GetFoodItemTableViewModel(user, date);

            return PartialView("FoodItemTable", viewModel);
        }


        public ActionResult Delete(int id, DateTime date)
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            _foodItemServices.DeleteFoodItem(id);

            var viewModel = GetFoodItemTableViewModel(user, date);

            return PartialView("FoodItemTable", viewModel);
        }



        private FoodItemTableViewModel GetFoodItemTableViewModel(User user, DateTime date)
        {
            List<FoodItem> foodItems = _foodItemServices.GetFoodItems(date, user.Id).OrderByDescending(x => x.Id).ToList();
            List<FoodItemViewModel> foodItemViewModel = Mapper.Map<List<FoodItem>, List<FoodItemViewModel>>(foodItems);

            var viewModel = new FoodItemTableViewModel()
            {
                FoodItems = foodItemViewModel
            };

            return viewModel;
        }



        private MealsTableViewModel GetMealsTableViewModel(User user, DateTime date)
        {
            List<Meal> meals = _mealServices.GetMeals(user.Id).OrderBy(x => x.Name).ToList();
            var mealsViewModel = Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(meals);

            var viewModel = new MealsTableViewModel()
            {
                Meals = mealsViewModel
            };

            return viewModel;
        }

        ///// <summary>
        ///// When we favourite something, we also want to save it - otherwise it is possible to edit a quantity, then
        ///// update the Favourites table without updating the FoodItems.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="quantity"></param>
        ///// <returns></returns>
        //public ActionResult Favourite(int id, int quantity)
        //{
        //    User user = _userServices.GetUser(User.Identity.Name);

        //    _foodItemServices.UpdateFoodItem(id, quantity);
        //    _foodItemServices.MergeFavourite(user.Id, id, quantity);

        //    return RedirectToAction("Index");
        //}


        //public ActionResult UseFavourite(string Code, DateTime date)
        //{
        //    User user = _userServices.GetUser(User.Identity.Name);

        //    Favourite favourite = _foodItemServices.GetFavourites(user.Id).Where(f => f.Code == Code).First();
        //    _foodItemServices.InsertFoodItem(Code, favourite.Quantity, date, user.Id);

        //    return RedirectToAction("Index");
        //}


        //public ActionResult DeleteFavourite(string Code)
        //{
        //    User user = _userServices.GetUser(User.Identity.Name);

        //    _foodItemServices.DeleteFavourite(user.Id, Code);

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Refresh(DateTime date)
        //{
        //    //User user = _userServices.GetUser(User.Identity.Name);
        //    User user = new User { Id = 1 };

        //    // Favourites
        //    List<Favourite> favourites = _foodItemServices.GetFavourites(user.Id).OrderBy(x => x.Name).ToList();
        //    var favouritesViewModel = Mapper.Map<IEnumerable<Favourite>, IEnumerable<FavouriteViewModel>>(favourites);

        //    // Food items
        //    List<FoodItem> foodItems = _foodItemServices.GetFoodItems(date, user.Id).OrderByDescending(x => x.Id).ToList();
        //    List<Product> products = _productServices.GetProducts(foodItems).ToList();
        //    var foodItemsViewModel = CalculateCaloriesByFoodItem(foodItems, products);

        //    // Meals
        //    List<Meal> meals = _mealServices.GetMeals(user.Id).OrderBy(x => x.Name).ToList();
        //    var mealsViewModel = Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(meals);


        //    var viewModel = new WeightFirstFoodItemListViewModel()
        //    {
        //        Favourites = favouritesViewModel,
        //        FoodItems = foodItemsViewModel,
        //        Meals = mealsViewModel,
        //        TotalCalories = CalculateTotalCalories(foodItemsViewModel)
        //    };

        //    return Json(viewModel, JsonRequestBehavior.AllowGet);
        //}


        //private decimal CalculateTotalCalories(List<WeightFirstFoodItemViewModel> foodItemsViewModel)
        //{
        //    decimal total = 0m;

        //    foreach (var item in foodItemsViewModel)
        //    {
        //        total += item.Calories;
        //    }

        //    return total;
        //}

        //private List<WeightFirstFoodItemViewModel> CalculateCaloriesByFoodItem(List<FoodItem> foodItems, List<Product> products)
        //{
        //    List<WeightFirstFoodItemViewModel> viewModel = Mapper.Map<List<FoodItem>, List<WeightFirstFoodItemViewModel>>(foodItems);

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