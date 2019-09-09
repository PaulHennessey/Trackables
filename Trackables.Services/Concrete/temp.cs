using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackables.Services.Concrete
{
    class temp
    {
        public List<List<decimal?>> CalculateMacroNutrientByProduct(List<Day> days, List<Product> products, string nutrient)
        {
            var allNutrients = new List<List<decimal?>>();
            var nutrients = new List<decimal?>();

            // Make a big list of all the fooditems from each day. The other one doesn't have this. This is to hold all the fooditems 
            // for every day. 
            List<FoodItem> foodItems = new List<FoodItem>();

            foreach (Day day in days)
            {
                foodItems.AddRange(day.Food); // The other one doesn't have this.

                // Now group the fooditems to get rid of repeats.
                var groupedFoodItems = foodItems.
                                       GroupBy(f => f.Code).
                                       Select(fg => new { Code = fg.Key, Total = fg.Sum(f => f.Quantity) }).ToList();

                var actualNutrientValues = from g in groupedFoodItems
                                           join p in products
                                           on g.Code equals p.Code
                                           select new
                                           {
                                               TotalNutrient = GetTotalMacroNutrient(g.Total, p, nutrient)
                                           };

                // Now convert the anonymous types to a list of objects for the Highchart. 
                decimal total = 0;
                foreach (var product in actualNutrientValues)
                {
                    nutrients.Add(product.TotalNutrient);
                    total += product.TotalNutrient;
                }

                nutrients.Add(total);
            }

            allNutrients.Add(nutrients);
            return allNutrients;
        }

    }
}
