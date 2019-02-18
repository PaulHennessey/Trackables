using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;
using MyFoodDiary.Domain.Extensions;

namespace MyFoodDiary.Data.Concrete
{
    public class ProductMapper : IProductMapper
    {
        public IEnumerable<Product> HydrateProducts(DataTable dataTable)
        {
            return from DataRow row in dataTable.Rows select new Product
            {
                Code = row["Code"].ToString(),
                Name = row["Name"].ToString(),
                ProductMacronutrients = HydrateMacronutrients(row),
                ProductMicronutrients = HydrateMicronutrients(row)
            };
        }

        private ProductMacronutrients HydrateMacronutrients(DataRow row)
        {
            ProductMacronutrients productMacronutrients = new ProductMacronutrients();

            foreach (Nutrient nutrient in Macronutrients.Nutrients)
            {
                productMacronutrients.ProductNutrients.Add(new ProductNutrient
                {
                    Name = nutrient.Name,
                    MeasurementUnit = nutrient.MeasurementUnit,
                    Quantity = row.GetValue(nutrient.Name)
                });
            }

            return productMacronutrients;
        }

        private ProductMicronutrients HydrateMicronutrients(DataRow row)
        {
            ProductMicronutrients productMicronutrients = new ProductMicronutrients();

            foreach (Nutrient nutrient in Micronutrients.Nutrients)
            {
                productMicronutrients.ProductNutrients.Add(new ProductNutrient
                {
                    Name = nutrient.Name,
                    MeasurementUnit = nutrient.MeasurementUnit,
                    Quantity = row.GetValue(nutrient.Name)
                });
            }

            return productMicronutrients;
        }

    }
}