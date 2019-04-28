using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Trackables.Domain;
using Trackables.Models;
using Trackables.Services.Abstract;

namespace Trackables.Controllers
{
    public class MealsController : Controller
    {
        private readonly IMealServices _mealServices;
        private readonly IIngredientServices _ingredientServices;
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;

        public MealsController()
        { }

        public MealsController(IMealServices mealServices, IUserServices userServices, IProductServices productServices, IIngredientServices ingredientServices)
        {
            _mealServices = mealServices;
            _userServices = userServices;
            _productServices = productServices;
            _ingredientServices = ingredientServices;
        }

        public ActionResult Index()
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            var viewModel = GetMealsModel(user);

            return View("Index", viewModel);
        }


        [HttpGet]
        public ViewResult Create()
        {
            MealViewModel mealViewModel = Mapper.Map<Meal, MealViewModel>(new Meal());

            return View(mealViewModel);
        }


        [HttpPost]
        public ActionResult Create(MealViewModel mealViewModel)
        {
            if (ModelState.IsValid)
            {
                //User user = _userServices.GetUser(User.Identity.Name);
                User user = new User { Id = 1 };

                Meal meal = Mapper.Map<MealViewModel, Meal>(mealViewModel);

                _mealServices.CreateMeal(meal, user.Id);

                return RedirectToAction("Index");
            }
            else
            {
                return View(mealViewModel);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Meal meal = _mealServices.GetMeal(id);

            MealViewModel mealViewModel = Mapper.Map<Meal, MealViewModel>(meal);

            return View(mealViewModel);
        }


        [HttpPost]
        public ActionResult Edit(MealViewModel mealViewModel)
        {
            if (ModelState.IsValid)
            {
                Meal meal = Mapper.Map<MealViewModel, Meal>(mealViewModel);

                _mealServices.UpdateMeal(meal);

                return RedirectToAction("Index");
            }
            else
            {
                return View(mealViewModel);
            }
        }


        /// <summary>
        /// This is called when you select a product from the autocomplete list.
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public ActionResult SelectFood(string code, int mealId)
        {
            User user = new User { Id = 1 };

            _ingredientServices.CreateIngredient(code, mealId);

            var viewModel = GetMealModel(user, mealId);

            return PartialView("IngredientsTable", viewModel);
        }


        public ActionResult DeleteMeal(int mealId)
        {
            User user = new User { Id = 1 };

            Meal meal = _mealServices.GetMeal(mealId);

            _mealServices.DeleteMeal(meal);

            var viewModel = GetMealsModel(user);

            return PartialView("MealsTable", viewModel);           
        }


        public ActionResult DeleteIngredient(int ingredientId, int mealId)
        {
            User user = new User { Id = 1 };

            _ingredientServices.DeleteIngredient(ingredientId);

            var viewModel = GetMealModel(user, mealId);

            return PartialView("IngredientsTable", viewModel);
        }


        public ActionResult SaveIngredient(int ingredientId, int mealId, int quantity)
        {
            User user = new User { Id = 1 };

            _ingredientServices.UpdateIngredient(ingredientId, quantity);

            var viewModel = GetMealModel(user, mealId);

            return PartialView("IngredientsTable", viewModel);
        }


        private MealViewModel GetMealModel(User user, int mealId)
        {
            Meal meal = _mealServices.GetMeal(mealId);

            MealViewModel viewModel = Mapper.Map<Meal, MealViewModel>(meal);

            return viewModel;
        }


        private MealsViewModel GetMealsModel(User user)
        {
            List<Meal> items = _mealServices.GetMeals(user.Id).OrderBy(x => x.Name).ToList();

            var viewModel = new MealsViewModel()
            {
                Meals = items
            };

            return viewModel;
        }
    }
}
