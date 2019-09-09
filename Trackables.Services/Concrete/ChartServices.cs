using System;
using System.Collections.Generic;
using System.Linq;
using Trackables.Domain;
using Trackables.Services.Abstract;

namespace Trackables.Services.Concrete
{
    public class ChartServices : IChartServices
    {
        private readonly IFoodItemServices _foodItemServices;
        private readonly IProductServices _productServices;

        // The Calorie Value of the different nutrients expressed as kcal/g
        private const decimal CalorieValueProtein = 4;
        private const decimal CalorieValueCarbohydrate = 4;
        private const decimal CalorieValueFat = 9;
        private const decimal CalorieValueAlcohol = 7;
        private const decimal SpecificGravityOfAlcohol = 0.789m;

        public ChartServices()
        {}

        public ChartServices(IFoodItemServices foodItemServices, IProductServices productServices)
        {
            _foodItemServices = foodItemServices;
            _productServices = productServices;
        }

        public List<List<decimal?>> CalculateMacronutrientByProduct(DateTime start, DateTime end, string nutrient, string UserId)
        {
            List<Day> days = _foodItemServices.GetDays(start, end, UserId).ToList();
            List<Product> products = _productServices.GetProducts(UserId, days).ToList();

            var productNutrients = new List<List<decimal?>>();

            // Make a big list of all the fooditems from each day.
            List<FoodItem> foodItems = new List<FoodItem>();
            foreach (Day day in days)
            {
                foodItems.AddRange(day.Food);
            }

            // Now group the fooditems to get rid of repeats.
            var groupedFoodItems = foodItems.
                                   GroupBy(f => f.Code).
                                   Select(fg => new { Code = fg.Key, Total = fg.Sum(f => f.Quantity) }).ToList();

            foreach (Day day in days)
            {
                var dayNutrients = new List<decimal?>();

                foreach(var g in groupedFoodItems)
                {
                    dayNutrients.Add(GetTotalMacroNutrient(g.Total, products.Where(p => p.Code == g.Code).First(),nutrient));
                }

                productNutrients.Add(dayNutrients);
            }

            return productNutrients;
        }


        public List<List<decimal?>> CalculateMicronutrientByProduct(DateTime start, DateTime end, string nutrient, string UserId)
        {
            List<Day> days = _foodItemServices.GetDays(start, end, UserId).ToList();
            List<Product> products = _productServices.GetProducts(UserId, days).ToList();

            var productNutrients = new List<List<decimal?>>();

            // Make a big list of all the fooditems from each day.
            List<FoodItem> foodItems = new List<FoodItem>();
            foreach (Day day in days)
            {
                foodItems.AddRange(day.Food);
            }

            // Now group the fooditems to get rid of repeats.
            var groupedFoodItems = foodItems.
                                   GroupBy(f => f.Code).
                                   Select(fg => new { Code = fg.Key, Total = fg.Sum(f => f.Quantity) }).ToList();

            foreach (Day day in days)
            {
                var dayNutrients = new List<decimal?>();

                foreach (var g in groupedFoodItems)
                {
                    dayNutrients.Add(GetTotalMicroNutrient(g.Total, products.Where(p => p.Code == g.Code).First(), nutrient));
                }

                productNutrients.Add(dayNutrients);
            }

            return productNutrients;
        }


        public List<List<decimal?>> CalculateMacronutrientByDay(DateTime start, DateTime end, string nutrient, string UserId)
        {
            List<Day> days = _foodItemServices.GetDays(start, end, UserId).ToList();
            List<Product> products = _productServices.GetProducts(UserId, days).ToList();

            var productNutrients = new List<List<decimal?>>();
            var dayNutrients = new List<decimal?>();

            foreach (Day day in days)
            {
                // Group the fooditems to get rid of repeats.
                var groupedFoodItems = day.Food.
                                       GroupBy(f => f.Code).
                                       Select(fg => new { Code = fg.Key, Total = fg.Sum(f => f.Quantity) }).ToList();

                foreach (var g in groupedFoodItems)
                {
                    dayNutrients.Add(GetTotalMacroNutrient(g.Total, products.Where(p => p.Code == g.Code).First(), nutrient));
                }
            }

            productNutrients.Add(dayNutrients);
            return productNutrients;
        }


        public List<List<decimal?>> CalculateMicronutrientByDay(DateTime start, DateTime end, string nutrient, string UserId)
        {
            List<Day> days = _foodItemServices.GetDays(start, end, UserId).ToList();
            List<Product> products = _productServices.GetProducts(UserId, days).ToList();

            var productNutrients = new List<List<decimal?>>();
            var dayNutrients = new List<decimal?>();

            foreach (Day day in days)
            {
                // Group the fooditems to get rid of repeats.
                var groupedFoodItems = day.Food.
                                       GroupBy(f => f.Code).
                                       Select(fg => new { Code = fg.Key, Total = fg.Sum(f => f.Quantity) }).ToList();

                foreach (var g in groupedFoodItems)
                {
                    dayNutrients.Add(GetTotalMicroNutrient(g.Total, products.Where(p => p.Code == g.Code).First(), nutrient));
                }
            }

            productNutrients.Add(dayNutrients);
            return productNutrients;
        }

        /// <summary>
        /// Note the alcohol data is stored as ABV, i.e. units of alcohol per 100ml. We want to display 'units', e.g. one 
        /// pint of Bass (4.2 ABV) is 2.4 units.
        /// This returns the amount of alcohol per product.
        /// </summary>
        /// <param name="days"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public List<List<decimal?>> CalculateAlcoholByProduct(List<Day> days, List<Product> products)
        {
            var allNutrients = new List<List<decimal?>>();
            var nutrients = new List<decimal?>();

            foreach (Day day in days)
            {
                var groupedFoodItemsByProduct = day.Food.
                                       GroupBy(f => f.Code).
                                       Select(fg => new { Code = fg.Key, Total = fg.Sum(f => f.Quantity) }).ToList();

                var alcoholConsumedByProduct = from g in groupedFoodItemsByProduct
                                               join p in products
                                               on g.Code equals p.Code
                                               select new
                                               {
                                                   AlcoholUnits = GetTotalAlcoholUnits(g.Total, p)
                                               };

                // Now convert the anonymous types to a list of objects for the Highchart. 
                decimal total = 0;
                foreach (var product in alcoholConsumedByProduct)
                {
                    nutrients.Add(product.AlcoholUnits);
                    total += product.AlcoholUnits;
                }

                nutrients.Add(Math.Round(total, 1));
            }

            allNutrients.Add(nutrients);
            return allNutrients;
        }

        /// <summary>
        /// This is used for the line chart.
        /// It returns the amount of alcohol per day.
        /// </summary>
        /// <param name="days"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public List<List<decimal?>> CalculateAlcoholByDay(List<Day> days, List<Product> products)
        {
            var allNutrients = new List<List<decimal?>>();
            var nutrients = new List<decimal?>();

            foreach (Day day in days)
            {
                var groupedFoodItemsByProduct = day.Food.
                                                GroupBy(f => f.Code).
                                                Select(fg => new { Code = fg.Key, Total = fg.Sum(f => f.Quantity) }).ToList();

                var alcoholConsumedByProduct = from g in groupedFoodItemsByProduct
                                               join p in products
                                               on g.Code equals p.Code
                                               select new
                                               {
                                                   AlcoholUnits = GetTotalAlcoholUnits(g.Total, p)
                                               };

                decimal alcoholConsumedByDay = alcoholConsumedByProduct.Sum(product => product.AlcoholUnits);
                nutrients.Add(alcoholConsumedByDay);
            }

            allNutrients.Add(nutrients);
            return allNutrients;
        }




        public List<List<decimal?>> CalculateMacronutrientRatioData(List<Day> days, List<Product> products)
        {
            var allNutrients = new List<List<decimal?>>();
            var carbsList = new List<decimal?>();
            var fatList = new List<decimal?>();
            var proteinList = new List<decimal?>();

            foreach (Day day in days)
            {
                // First group the fooditems in case there are repeats, e.g. two apples.
                var groupedFoodItems = day.Food.
                                       GroupBy(f => f.Code).
                                       Select(fg => new { Code = fg.Key, Total = fg.Sum(f => f.Quantity) }).ToList();


                var actualCarbohydrateValues = from g in groupedFoodItems
                                               join p in products
                                               on g.Code equals p.Code
                                               select new
                                               {
                                                   TotalNutrient = GetTotalMacroNutrient(g.Total, p, "Carbohydrates")
                                               };

                var actualProteinValues = from g in groupedFoodItems
                                          join p in products
                                          on g.Code equals p.Code
                                          select new
                                          {
                                              TotalNutrient = GetTotalMacroNutrient(g.Total, p, "Protein")
                                          };

                var actualFatValues = from g in groupedFoodItems
                                      join p in products
                                      on g.Code equals p.Code
                                      select new
                                      {
                                          TotalNutrient = GetTotalMacroNutrient(g.Total, p, "Fat")
                                      };

                // Now convert the anonymous types to a list of objects for the Highchart.
                decimal carbohydrates = actualCarbohydrateValues.Sum(product => product.TotalNutrient);
                decimal protein = actualProteinValues.Sum(product => product.TotalNutrient);
                decimal fat = actualFatValues.Sum(product => product.TotalNutrient);

                decimal carbohydrateCalories = carbohydrates * CalorieValueCarbohydrate;
                decimal proteinCalories = protein * CalorieValueProtein;
                decimal fatCalories = fat * CalorieValueFat;
                decimal totalCalories = carbohydrateCalories + proteinCalories + fatCalories;

                carbsList.Add(Math.Round((carbohydrateCalories / totalCalories) * 100, 1));
                proteinList.Add(Math.Round((proteinCalories / totalCalories) * 100, 1));
                fatList.Add(Math.Round((fatCalories / totalCalories) * 100, 1));

              
            }

            allNutrients.Add(carbsList);
            allNutrients.Add(proteinList);
            allNutrients.Add(fatList);
            return allNutrients;
        }


        public List<string> GetBarNames(IEnumerable<FoodItem> foodItems)
        {
            // First group the fooditems in case there are repeats, e.g. two apples.
            var groupedFoodItems = foodItems.
                                   GroupBy(f => f.Code).
                                   Select(fg => new { fg.First().Name });

            var names = groupedFoodItems.Select(g => g.Name).ToList();
            names.Add("Total");

            return names;
        }


        public List<string> GetBarNames(IEnumerable<Day> days)
        {
            // Make a big list of all the fooditems from each day.
            List<FoodItem> foodItems = new List<FoodItem>();
            foreach (Day day in days)
            {
                foodItems.AddRange(day.Food);
            }

            // Now group the fooditems to get rid of repeats.
            List<string> names = foodItems.
                                   GroupBy(f => f.Code).
                                   Select(fg => fg.First().Name).ToList();

        //    names.Add("Total");
            return names;
        }


        public List<string> GetDates(IEnumerable<Day> days)
        {
            return days.Select(d => d.Date.ToShortDateString()).ToList();
        }


        public List<string> GetMacronutrientRatioCategories()
        {
            return new List<string> { "% Carbohydrates", "% Protein", "% Fat" };
        }


        public List<string> GetMacronutrientTitle(string name)
        {
            Nutrient nutrient = Macronutrients.Nutrient(name);
            return new List<string> { nutrient.Name + " in " + nutrient.MeasurementUnit };
        }


        public List<string> GetMicronutrientTitle(string name)
        {
            Nutrient nutrient = Micronutrients.Nutrient(name);
            return new List<string> { nutrient.Name + " in " + nutrient.MeasurementUnit };
        }


        private decimal GetTotalMacroNutrient(int total, Product product, string nutrient)
        {
            if (nutrient == "Calories")
                return Math.Round(total * (product.ProductMacronutrients.Quantity(nutrient) / 100), 0);
            else
                return Math.Round(total * (product.ProductMacronutrients.Quantity(nutrient) / 100), 1);
        }

        private decimal GetTotalMicroNutrient(int total, Product product, string nutrient)
        {
            return Math.Round(total * (product.ProductMicronutrients.Quantity(nutrient) / 100), 1);
        }

        /// <summary>
        /// Alcohol (ALCO). Values are given as g/100 ml. Pure ethyl alcohol has a
        /// specific gravity of 0.789, dividing values by 0.789 converts them to alcohol by
        /// volume(ml/100 ml). 
        /// 
        /// So to calculate units, (ABV * vol(ml))/1000.
        /// </summary>
        /// <param name="total"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        private decimal GetTotalAlcoholUnits(int total, Product product)
        {           
            decimal alcoholByWeight = product.ProductMacronutrients.Quantity("Alcohol");
            decimal alcoholByVolume = alcoholByWeight / SpecificGravityOfAlcohol;

            return Math.Round((alcoholByVolume * total) / 1000, 1);
        }

        public decimal GetMacronutrientRDA(string name)
        {
            return Macronutrients.Nutrient(name).RDA;
        }

        public decimal GetMicronutrientRDA(string name)
        {
            return Micronutrients.Nutrient(name).RDA;
        }
    }
}
