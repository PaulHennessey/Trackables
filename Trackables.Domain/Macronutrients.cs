using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFoodDiary.Domain
{
    public static class Macronutrients
    {
        public static List<Nutrient> Nutrients = new List<Nutrient>
        {
            new Nutrient { Id = 1, Name = "Calories", MeasurementUnit = "kcal", RDA = 1500},
            new Nutrient { Id = 2, Name = "Protein", MeasurementUnit = "grams", RDA = 100 },
            new Nutrient { Id = 3, Name = "Carbohydrates", MeasurementUnit = "grams", RDA = 150 },
            new Nutrient { Id = 4, Name = "Total Sugars", MeasurementUnit = "grams", RDA = 25 },
            new Nutrient { Id = 5, Name = "Fat", MeasurementUnit = "grams", RDA = 100 },
            new Nutrient { Id = 6, Name = "Alcohol", MeasurementUnit = "units", RDA = 2 },
            new Nutrient { Id = 7, Name = "Fibre", MeasurementUnit = "grams", RDA = 25 }
        };

        public static Nutrient Nutrient(string name)
        {
            return Nutrients.Where(m => m.Name == name).First();
        }

    }
}
