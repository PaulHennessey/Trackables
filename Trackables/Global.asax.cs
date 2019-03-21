//using Trackables;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http;
//using System.Web.Mvc;
//using System.Web.Optimization;
//using System.Web.Routing;

using AutoMapper;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Trackables;
using Trackables.Domain;
using Trackables.Models;

namespace Trackables
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, Product>();
                cfg.CreateMap<FoodItem, FoodItemViewModel>();
                cfg.CreateMap<FoodItem, WeightFirstFoodItemViewModel>();
                cfg.CreateMap<FoodItem, CaloriesFirstFoodItemViewModel>();
                cfg.CreateMap<Favourite, FavouriteViewModel>();
                cfg.CreateMap<Product, ProductAutocompleteViewModel>()
                    .ForMember(dest => dest.label, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.Code));
                cfg.CreateMap<Meal, MealViewModel>();
            });


            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
