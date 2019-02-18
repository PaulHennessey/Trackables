using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFoodDiary.Domain
{
    public static class Micronutrients
    {
        public static List<Nutrient> Nutrients = new List<Nutrient>
        {
            new Nutrient { Name = "Calcium", MeasurementUnit = "mg", RDA = 1000 },
            new Nutrient { Name = "Sodium", MeasurementUnit = "mg", RDA = 2.4M },
            new Nutrient { Name = "Potassium", MeasurementUnit = "mg", RDA = 4700 },
            new Nutrient { Name = "Magnesium", MeasurementUnit = "mg", RDA = 420 },
            new Nutrient { Name = "Iron", MeasurementUnit = "mg", RDA = 8 },
            new Nutrient { Name = "Copper", MeasurementUnit = "mg", RDA = 0.7M },
            new Nutrient { Name = "Zinc", MeasurementUnit = "mg", RDA = 10 },
            new Nutrient { Name = "Manganese", MeasurementUnit = "mg", RDA = 2.3M },
            new Nutrient { Name = "Phosphorus", MeasurementUnit = "mg", RDA = 700 },
            new Nutrient { Name = "Selenium", MeasurementUnit = "µg", RDA = 55 },
            new Nutrient { Name = "Vitamin D", MeasurementUnit = "µg", RDA = 10 },
            new Nutrient { Name = "Vitamin C", MeasurementUnit = "mg", RDA = 100 },
            new Nutrient { Name = "Vitamin E", MeasurementUnit = "mg", RDA = 15 },
            new Nutrient { Name = "Vitamin K1", MeasurementUnit = "µg", RDA = 120 },
            new Nutrient { Name = "Vitamin B6", MeasurementUnit = "mg", RDA = 1.7M },
            new Nutrient { Name = "Vitamin B12", MeasurementUnit = "µg", RDA = 2.4M },
            new Nutrient { Name = "Vitamin A", MeasurementUnit = "µg", RDA = 900 },
            new Nutrient { Name = "Carotene", MeasurementUnit = "µg", RDA = 2.4M },
            new Nutrient { Name = "Pantothenic Acid", MeasurementUnit = "mg", RDA = 5 },
            new Nutrient { Name = "Thiamin", MeasurementUnit = "mg", RDA = 1.1M },
            new Nutrient { Name = "Riboflavin", MeasurementUnit = "mg", RDA = 1.3M },
            new Nutrient { Name = "Niacin", MeasurementUnit = "mg", RDA = 16 },
            new Nutrient { Name = "Folate", MeasurementUnit = "µg", RDA = 400 }
        };



        public static Nutrient Nutrient(string name)
        {
            return Nutrients.Where(m => m.Name == name).First();
        }
    }
}
