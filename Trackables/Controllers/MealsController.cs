using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Trackables.Domain;
using Trackables.Models;
using Trackables.Services.Abstract;

namespace Trackables.Controllers
{
    [Authorize]
    public class MealsController : Controller
    {
        private readonly IMealServices _mealServices;
        private readonly IIngredientServices _ingredientServices;
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;

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
            var viewModel = GetMealsModel();

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
                Meal meal = Mapper.Map<MealViewModel, Meal>(mealViewModel);

                _mealServices.CreateMeal(meal, UserId);

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
            Meal meal = _mealServices.GetMeal(UserId, id);

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
            _ingredientServices.CreateIngredient(code, mealId);

            var viewModel = GetMealModel(mealId);

            return PartialView("IngredientsTable", viewModel);
        }


        public ActionResult DeleteMeal(int mealId)
        {
            Meal meal = _mealServices.GetMeal(UserId, mealId);

            _mealServices.DeleteMeal(meal);

            var viewModel = GetMealsModel();

            return PartialView("MealsTable", viewModel);           
        }


        public ActionResult DeleteIngredient(int ingredientId, int mealId)
        {
            _ingredientServices.DeleteIngredient(ingredientId);

            var viewModel = GetMealModel(mealId);

            return PartialView("IngredientsTable", viewModel);
        }


        public ActionResult SaveIngredient(int ingredientId, int mealId, int quantity)
        {
            _ingredientServices.UpdateIngredient(ingredientId, quantity);

            var viewModel = GetMealModel(mealId);

            return PartialView("IngredientsTable", viewModel);
        }


        private MealViewModel GetMealModel(int mealId)
        {
            Meal meal = _mealServices.GetMeal(UserId, mealId);

            MealViewModel viewModel = Mapper.Map<Meal, MealViewModel>(meal);

            return viewModel;
        }


        private MealsViewModel GetMealsModel()
        {
            List<Meal> items = _mealServices.GetMeals(UserId).OrderBy(x => x.Name).ToList();

            var viewModel = new MealsViewModel()
            {
                Meals = items
            };

            return viewModel;
        }
    }
}
