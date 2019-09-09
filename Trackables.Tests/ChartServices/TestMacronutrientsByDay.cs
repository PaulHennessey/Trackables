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
    public class TestMacronutrientByDay
    {
        private readonly Dictionary<string, decimal> Macronutrients = new Dictionary<string, decimal>()
        {
            { "Calories", 50.0m }
        };

        Mock<IFoodItemServices> myFoodItemServices = new Mock<IFoodItemServices>();
        Mock<IProductServices> myProductServices = new Mock<IProductServices>();

        [TestMethod]
        public void TestCalculateMacronutrientByDayOneProductOneDay()
        {
            // Arrange
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}}
            });

            // Act
            var result = chartServices.CalculateMacronutrientByDay(DateTime.Now, DateTime.Now, "Calories", It.IsAny<string>());

            // Assert
            Assert.AreEqual(5, result[0].Sum());
        }

        [TestMethod]
        public void TestCalculateMacronutrientByDayOneProductTwoDays()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 20}}}
            });

            // Act
            var result = chartServices.CalculateMacronutrientByDay(DateTime.Now, DateTime.Now, "Calories", It.IsAny<string>());

            // Assert
            Assert.AreEqual(15, result[0].Sum());
        }

        [TestMethod]
        public void TestCalculateMacronutrientByDayTwoProductsOneDay()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)},
                new Product { Code = "YYY", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "YYY", Quantity = 20}}}
            });

            // Act
            var result = chartServices.CalculateMacronutrientByDay(DateTime.Now, DateTime.Now, "Calories", It.IsAny<string>());

            // Assert
            Assert.AreEqual(15, result[0].Sum());
        }

        [TestMethod]
        public void TestCalculateMacronutrientByDayTwoSameProductsOneDay()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)},
                new Product { Code = "YYY", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 20}}}
            });

            // Act
            var result = chartServices.CalculateMacronutrientByDay(DateTime.Now, DateTime.Now, "Calories", It.IsAny<string>());

            // Assert
            Assert.AreEqual(15, result[0].Sum());
        }

        [TestMethod]
        public void TestCalculateMacronutrientByDayFourProductsOneDay()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)},
                new Product { Code = "YYY", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)}
            });

            myFoodItemServices.Setup(m => m.GetDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Day>
            {
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 10}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "XXX", Quantity = 20}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "YYY", Quantity = 30}}},
                new Day {Food = new List<FoodItem> {new FoodItem {Code = "YYY", Quantity = 40}}}
            });

            // Act
            var result = chartServices.CalculateMacronutrientByDay(DateTime.Now, DateTime.Now, "Calories", It.IsAny<string>());

            // Assert
            Assert.AreEqual(50, result[0].Sum());
        }


        [TestMethod]
        public void TestCalculateMacronutrientByDayTwoProductsTwoDays()
        {
            ChartServices chartServices = new ChartServices(myFoodItemServices.Object, myProductServices.Object);
            var productServices = new ProductServices();

            myProductServices.Setup(m => m.GetProducts(It.IsAny<string>(), It.IsAny<List<Day>>())).Returns(new List<Product>
            {
                new Product { Code = "XXX", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)},
                new Product { Code = "YYY", ProductMacronutrients = productServices.UpdateProductMacronutrients(Macronutrients)}
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
            var result = chartServices.CalculateMacronutrientByDay(DateTime.Now, DateTime.Now, "Calories", It.IsAny<string>());

            // Assert
            Assert.AreEqual(50, result[0].Sum());
        }
    }
}
