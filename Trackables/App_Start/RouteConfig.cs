using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Trackables
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Trackables",
                url: "trackables/trackables",
                defaults: new { controller = "Trackables", action = "Index" }
            );

            routes.MapRoute(
                name: "Meals",
                url: "trackables/meals",
                defaults: new { controller = "Meals", action = "Index" }
            );

            routes.MapRoute(
                name: "Products",
                url: "trackables/products",
                defaults: new { controller = "Products", action = "Index" }
            );

            routes.MapRoute(
                name: "Micronutrients",
                url: "trackables/micronutrients",
                defaults: new { controller = "Micronutrients", action = "Index" }
            );

            routes.MapRoute(
                name: "Macronutrients",
                url: "trackables/macronutrients",
                defaults: new { controller = "Macronutrients", action = "Index" }
            );

            routes.MapRoute(
                name: "TrackablesLog",
                url: "trackables/trackableslog",
                defaults: new { controller = "TrackablesLog", action = "Index" }
            );

            routes.MapRoute(
                name: "FoodLog",
                url: "trackables/foodlog",
                defaults: new { controller = "FoodLog", action = "Index" }
            );

            routes.MapRoute(
                name: "FretwireHome",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "TrackablesHome",
                url: "trackables",
                defaults: new { controller = "TrackablesHome", action = "Index" }
            );

            // Trackable Items
            routes.MapRoute(
                name: "SaveTrackableItem",
                url: "TrackablesLog/Save/{id}/{trackableId}/{quantity}/{date}",
                defaults: new { controller = "TrackablesLog", action = "Save", id = UrlParameter.Optional, quantity = UrlParameter.Optional }
            );

            // Meals 
            routes.MapRoute(
                name: "EditMeal",
                url: "Meals/Edit/{id}",               
                defaults: new { controller = "Meals", action = "Edit" }
            );

            routes.MapRoute(
                name: "SaveIngredient",
                url: "Meals/SaveIngredient/{ingredientid}/{mealid}",
                defaults: new { controller = "Meals", action = "SaveIngredient" }
            );

            routes.MapRoute(
                name: "DeleteIngredient",
                url: "{controller}/{action}/{ingredientId}/{mealId}",
                defaults: new { controller = "Home", action = "Index", ingredientId = UrlParameter.Optional, mealId = UrlParameter.Optional }
            );

            // Products
            routes.MapRoute(
                name: "DeleteProduct",
                url: "{controller}/{action}/{code}",
                defaults: new { controller = "Home", action = "Index", code = UrlParameter.Optional }
            );

            // Defaults
            routes.MapRoute(
                name: "Save",
                url: "{controller}/{action}/{id}/{quantity}/{date}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, quantity = UrlParameter.Optional, date = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Delete",
                url: "{controller}/{action}/{id}/{date}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, date = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
