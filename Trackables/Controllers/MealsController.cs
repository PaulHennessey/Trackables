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

            List<Meal> items = _mealServices.GetMeals(user.Id).OrderBy(x => x.Name).ToList();

            var viewModel = new MealsViewModel()
            {
                Meals = items
            };

            return View("Index", viewModel);
        }


        [HttpGet]
        public ViewResult Create()
        {
            Meal meal = new Meal()
            {
                Name = String.Empty,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient{ Id = 1, MealId = 1, Code = "aaa", Quantity = 10 },
                    new Ingredient{ Id = 2, MealId = 1, Code = "bbb", Quantity = 20 },
                    new Ingredient{ Id = 3, MealId = 1, Code = "ccc", Quantity = 30 }
                }
            };

            MealViewModel mealViewModel = Mapper.Map<Meal, MealViewModel>(meal);

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
        /// This gives the autocomplete field a list of products.
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public ActionResult Search(string term)
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            List<Product> items = _productServices.GetProducts(user.Id).ToList();

            var filteredItems = items.Where(item => item.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0);

            IEnumerable<AutocompleteViewModel> viewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<AutocompleteViewModel>>(filteredItems);
            //MealViewModel mealViewModel = new MealViewModel { Autocomplete = viewModel };


            return Json(viewModel, JsonRequestBehavior.AllowGet);
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

            return RedirectToAction("Edit", new { id = mealId });
        }


        public ActionResult CountryLookup()
        {
            var countries = new List<SearchTypeAheadEntity>
        {
            new SearchTypeAheadEntity {ShortCode = "US", Name = "United States"},
            new SearchTypeAheadEntity {ShortCode = "CA", Name = "Canada"},
            new SearchTypeAheadEntity {ShortCode = "AF", Name = "Afghanistan"},
            new SearchTypeAheadEntity {ShortCode = "AL", Name = "Albania"},
            new SearchTypeAheadEntity {ShortCode = "DZ", Name = "Algeria"},
            new SearchTypeAheadEntity {ShortCode = "DS", Name = "American Samoa"},
            new SearchTypeAheadEntity {ShortCode = "AD", Name = "Andorra"},
            new SearchTypeAheadEntity {ShortCode = "AO", Name = "Angola"},
            new SearchTypeAheadEntity {ShortCode = "AI", Name = "Anguilla"},
            new SearchTypeAheadEntity {ShortCode = "AQ", Name = "Antarctica"},
            new SearchTypeAheadEntity {ShortCode = "AG", Name = "Antigua and/or Barbuda"}
        };

            return Json(countries, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteMeal(int mealId)
        {
            Meal meal = _mealServices.GetMeal(mealId);

            _mealServices.DeleteMeal(meal);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteIngredient(int id, int mealId)
        {
            _ingredientServices.DeleteIngredient(id);

            return RedirectToAction("Edit", new { id = mealId });
        }

        public ActionResult SaveIngredient(int id, int mealId, int quantity)
        {
            _ingredientServices.UpdateIngredient(id, quantity);

            return RedirectToAction("Edit", new { id = mealId });
        }
    }
}
