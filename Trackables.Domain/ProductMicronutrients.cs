﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFoodDiary.Domain
{
    public class ProductMicronutrients
    {
        public ProductMicronutrients InitialiseList()
        {
            foreach (Nutrient nutrient in Micronutrients.Nutrients)
            {
                ProductNutrients.Add(new ProductNutrient
                {
                    Name = nutrient.Name,
                    MeasurementUnit = nutrient.MeasurementUnit,
                    Quantity = 0.0m
                });
            }

            return this;
        }

        public List<ProductNutrient> ProductNutrients = new List<ProductNutrient>();

        public decimal Quantity(string name)
        {
            return this.ProductNutrients.Where(n => n.Name == name).First().Quantity;
        }

        public void Update(string name, decimal value)
        {
            ProductNutrients.Where(n => n.Name == name).First().Quantity = value;
        }
    }
}
