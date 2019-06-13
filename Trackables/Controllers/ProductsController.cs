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
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
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

        public ProductsController()
        { }

        public ProductsController(IProductServices productServices, IUserServices userServices)
        {
            _productServices = productServices;
            _userServices = userServices;
        }

        public ActionResult Index()
        {
            List<Product> items = _productServices.GetCustomProducts(UserId).OrderBy(x => x.Name).ToList();

            var viewModel = new ProductsViewModel()
            {
                Products = items
            };

            return View("Index", viewModel);
        }


        public ActionResult Delete(string code)
        {
            _productServices.DeleteProduct(code);

            var viewModel = GetModel();

            return PartialView("ProductTable", viewModel);
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
                Product product = Mapper.Map<ProductViewModel, Product>(productViewModel);
                product.ProductMacronutrients = _productServices.UpdateProductMacronutrients(productViewModel.MacroNutrients);
                product.ProductMicronutrients = _productServices.UpdateProductMicronutrients(productViewModel.MicroNutrients);

                _productServices.CreateProduct(product, UserId);

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
            Product product = _productServices.GetProduct(UserId, code);

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

                _productServices.UpdateProduct(UserId, product);

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
            List<Product> items = _productServices.GetProducts(UserId).ToList();

            IEnumerable<Autocomplete> viewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<Autocomplete>>(items);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        private ProductsViewModel GetModel()
        {
            List<Product> items = _productServices.GetCustomProducts(UserId).OrderBy(x => x.Name).ToList();

            var viewModel = new ProductsViewModel()
            {
                Products = items
            };

            return viewModel;
        }

    }
}