﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Trackables.Domain;
using Trackables.Services.Abstract;
using Trackables.Services.Concrete;

namespace Trackables.Tests
{
    [TestClass]
    public class TestMicronutrientByProduct
    {
        private readonly Dictionary<string, decimal> Micronutrients = new Dictionary<string, decimal>()
        {
            { "Folate", 50.0m },
            { "Calcium", 50.0m }
        };

        Mock<IServingServices> myServingServices = new Mock<IServingServices>();
        Mock<IProductServices> myProductServices = new Mock<IProductServices>();

        [TestMethod]
        public void TestCalculateMacroNutrientByProductOneServing()
        {
            // Arrange            
            ChartServices chartServices = new ChartServices(myServingServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)}
            });

            myServingServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<Serving> {new Serving {Code = "XXX", Quantity = 10}}}
            });

            var nutrients = new List<string>
            {
                "Folate"
            };

            var expected = new List<List<decimal?>>
            {
                new List<decimal?>{5}
            };

            // Act
            var actual = chartServices.CalculateMicronutrientByProduct(DateTime.Now, DateTime.Now, nutrients, It.IsAny<string>());

            // Assert
            CollectionAssert.AreEqual(expected[0], actual[0]);
        }

        [TestMethod]
        public void TestCalculateMacroNutrientByProductTwoServings()
        {
            // Arrange            
            ChartServices chartServices = new ChartServices(myServingServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)}
            });

            myServingServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<Serving>
                {
                    new Serving {Code = "XXX", Quantity = 10},
                    new Serving {Code = "XXX", Quantity = 20}
                }}
            });

            var nutrients = new List<string>
            {
                "Folate"
            };

            var expected = new List<List<decimal?>>
            {
                new List<decimal?>{15},
            };

            // Act
            var actual = chartServices.CalculateMicronutrientByProduct(DateTime.Now, DateTime.Now, nutrients, It.IsAny<string>());

            // Assert
            CollectionAssert.AreEqual(expected[0], actual[0]);
        }


        [TestMethod]
        public void TestCalculateMacroNutrientByProductTwoDifferentServings()
        {
            // Arrange            
            ChartServices chartServices = new ChartServices(myServingServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)},
                new Product { Code = "YYY", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)}
            });

            myServingServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<Serving>
                {
                    new Serving {Code = "XXX", Quantity = 10},
                    new Serving {Code = "YYY", Quantity = 20}
                }}
            });

            var nutrients = new List<string>
            {
                "Folate",
                "Calcium"
            };

            var expected = new List<List<decimal?>>
            {
                new List<decimal?>{5,10},
                new List<decimal?>{5,10}
            };

            // Act
            var actual = chartServices.CalculateMicronutrientByProduct(DateTime.Now, DateTime.Now, nutrients, It.IsAny<string>());

            // Assert
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
        }
    }
}
