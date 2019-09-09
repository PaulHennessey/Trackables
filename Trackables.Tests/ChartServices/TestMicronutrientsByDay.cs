using System;
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
    public class TestMicronutrientByDay
    {
        private readonly Dictionary<string, decimal> Micronutrients = new Dictionary<string, decimal>()
        {
            { "Folate", 50.0m }
        };

        Mock<IFoodItemServices> myFoodItemServices = new Mock<IFoodItemServices>();
        Mock<IProductServices> myProductServices = new Mock<IProductServices>();

        [TestMethod]
        public void TestCalculateMicronutrientByDayOneProductOneDay()
        {
            // Arrange
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}}
            });

            // Act
            var result = chartServices.CalculateMicronutrientByDay(DateTime.Now, DateTime.Now, "Folate", It.IsAny<string>());

            // Assert
            Assert.AreEqual(5, result[0].Sum());
        }

        [TestMethod]
        public void TestCalculateMicronutrientByDayOneProductTwoDays()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 20}}}
            });

            // Act
            var result = chartServices.CalculateMicronutrientByDay(DateTime.Now, DateTime.Now, "Folate", It.IsAny<string>());

            // Assert
            Assert.AreEqual(15, result[0].Sum());
        }

        [TestMethod]
        public void TestCalculateMicronutrientByDayTwoProductsOneDay()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)},
                new Product { Code = "YYY", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "YYY", Quantity = 20}}}
            });

            // Act
            var result = chartServices.CalculateMicronutrientByDay(DateTime.Now, DateTime.Now, "Folate", It.IsAny<string>());

            // Assert
            Assert.AreEqual(15, result[0].Sum());
        }

        [TestMethod]
        public void TestCalculateMicronutrientByDayTwoSameProductsOneDay()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)},
                new Product { Code = "YYY", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 20}}}
            });

            // Act
            var result = chartServices.CalculateMicronutrientByDay(DateTime.Now, DateTime.Now, "Folate", It.IsAny<string>());

            // Assert
            Assert.AreEqual(15, result[0].Sum());
        }

        [TestMethod]
        public void TestCalculateMicronutrientByDayFourProductsOneDay()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)},
                new Product { Code = "YYY", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 20}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "YYY", Quantity = 30}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "YYY", Quantity = 40}}}
            });

            // Act
            var result = chartServices.CalculateMicronutrientByDay(DateTime.Now, DateTime.Now, "Folate", It.IsAny<string>());

            // Assert
            Assert.AreEqual(50, result[0].Sum());
        }


        [TestMethod]
        public void TestCalculateMicronutrientByDayTwoProductsTwoDays()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)},
                new Product { Code = "YYY", ProductMicronutrients = productServices.UpdateProductMicronutrients(Micronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {
                    new FoodItem{Code = "XXX", Quantity = 10},
                    new FoodItem{Code = "YYY", Quantity = 20}
                }},
                new Day {Food = new List<FoodItem> {
                    new FoodItem{Code = "XXX", Quantity = 30},
                    new FoodItem{Code = "YYY", Quantity = 40}
                }}
            });

            // Act
            var result = chartServices.CalculateMicronutrientByDay(DateTime.Now, DateTime.Now, "Folate", It.IsAny<string>());

            // Assert
            Assert.AreEqual(50, result[0].Sum());
        }
    }
}
