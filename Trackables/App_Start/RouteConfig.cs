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
                name: "TrackablesChart",
                url: "trackables/trackableschart",
                defaults: new { controller = "TrackablesChart", action = "Index" }
            );

            routes.MapRoute(
                name: "TrackablesManageLogins",
                url: "trackables/manage/managelogins",
                defaults: new { controller = "Manage", action = "ManageLogins" }
            );

            routes.MapRoute(
                name: "TrackablesSetPassword",
                url: "trackables/manage/setpassword",
                defaults: new { controller = "Manage", action = "SetPassword" }
            );

            routes.MapRoute(
                name: "TrackablesChangePassword",
                url: "trackables/manage/changepassword",
                defaults: new { controller = "Manage", action = "ChangePassword" }
            );

            routes.MapRoute(
                name: "TrackablesManage",
                url: "trackables/manage",
                defaults: new { controller = "Manage", action = "Index" }
            );

            routes.MapRoute(
                name: "TrackablesLogin",
                url: "trackables/login",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "TrackablesRegister",
                url: "trackables/register",
                defaults: new { controller = "Account", action = "Register" }
            );

            routes.MapRoute(
                name: "Trackables",
                url: "trackables/trackables",
                defaults: new { controller = "Trackables", action = "Index" }
            );

            routes.MapRoute(
                name: "CreateTrackable",
                url: "trackables/trackables/create",
                defaults: new { controller = "Trackables", action = "Create" }
            );

            routes.MapRoute(
                name: "EditTrackable",
                url: "trackables/trackables/edit/{id}",
                defaults: new { controller = "Trackables", action = "Edit" }
            );

            routes.MapRoute(
                name: "Meals",
                url: "trackables/meals",
                defaults: new { controller = "Meals", action = "Index" }
            );

            routes.MapRoute(
                name: "CreateMeal",
                url: "trackables/meals/create",
                defaults: new { controller = "Meals", action = "Create" }
            );

            routes.MapRoute(
                name: "EditMeal",
                url: "trackables/meals/edit/{id}",
                defaults: new { controller = "Meals", action = "Edit" }
            );

            routes.MapRoute(
                name: "Products",
                url: "trackables/products",
                defaults: new { controller = "Products", action = "Index" }
            );

            routes.MapRoute(
                name: "CreateProduct",
                url: "trackables/products/create",
                defaults: new { controller = "Products", action = "Create" }
            );

            routes.MapRoute(
                name: "EditProduct",
                url: "trackables/products/edit/{code}",
                defaults: new { controller = "Products", action = "Edit" }
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

            //// Meals 
            //routes.MapRoute(
            //    name: "EditMeal",
            //    url: "Meals/Edit/{id}",               
            //    defaults: new { controller = "Meals", action = "Edit" }
            //);

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
