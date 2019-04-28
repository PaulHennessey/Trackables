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
  
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IUserServices _userServices;

        public ProductsController()
        { }

        public ProductsController(IProductServices productServices, IUserServices userServices)
        {
            _productServices = productServices;
            _userServices = userServices;
        }

        public ActionResult Index()
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            List<Product> items = _productServices.GetCustomProducts(user.Id).OrderBy(x => x.Name).ToList();

            var viewModel = new ProductsViewModel()
            {
                Products = items
            };

            //return PartialView("ProductTable", viewModel);

            return View("Index", viewModel);
        }


        public ActionResult Delete(string code)
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            _productServices.DeleteProduct(code);

            var viewModel = GetModel(user);

            return PartialView("ProductTable", viewModel);
        }



        private ProductsViewModel GetModel(User user)
        {
            List<Product> items = _productServices.GetCustomProducts(user.Id).OrderBy(x => x.Name).ToList();

            var viewModel = new ProductsViewModel()
            {
                Products = items
            };

            return viewModel;
        }



        [HttpGet]
        public ViewResult Create()
        {
            Product product = new Product()
            {
                Code = String.Empty,
                ProductMacronutrients = new ProductMacronutrients().InitialiseList(),
                ProductMicronutrients = new ProductMicronutrients().InitialiseList(),
            };

            ProductViewModel productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            productViewModel.MacroNutrients = _productServices.GetMacroNutrients(product);
            productViewModel.MicroNutrients = _productServices.GetMicroNutrients(product);

            return View(productViewModel);
        }


        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                //User user = _userServices.GetUser(User.Identity.Name);
                User user = new User { Id = 1 };

                Product product = Mapper.Map<ProductViewModel, Product>(productViewModel);
                product.ProductMacronutrients = _productServices.UpdateProductMacronutrients(productViewModel.MacroNutrients);
                product.ProductMicronutrients = _productServices.UpdateProductMicronutrients(productViewModel.MicroNutrients);

                _productServices.CreateProduct(product, user.Id);

                return RedirectToAction("Index");
            }
            else
            {
                return View(productViewModel);
            }
        }


        [HttpGet]
        public ActionResult Edit(string code)
        {
            Product product = _productServices.GetProduct(code);

            ProductViewModel productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            productViewModel.MacroNutrients = _productServices.GetMacroNutrients(product);
            productViewModel.MicroNutrients = _productServices.GetMicroNutrients(product);

            return View(productViewModel);
        }


        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<ProductViewModel, Product>(productViewModel);
                product.ProductMacronutrients = _productServices.UpdateProductMacronutrients(productViewModel.MacroNutrients);
                product.ProductMicronutrients = _productServices.UpdateProductMicronutrients(productViewModel.MicroNutrients);

                _productServices.UpdateProduct(product);

                return RedirectToAction("Index");
            }
            else
            {
                return View(productViewModel);
            }
        }


        /// <summary>
        /// This is used by the typeahead prefetch function.
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductFetch()
        {
            //User user = _userServices.GetUser(User.Identity.Name);
            User user = new User { Id = 1 };

            List<Product> items = _productServices.GetProducts(user.Id).ToList();

            IEnumerable<Autocomplete> viewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<Autocomplete>>(items);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

    }
}