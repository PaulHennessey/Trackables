using System.Collections.Generic;
using System.Data;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;
using Trackables.Services.Abstract;

namespace Trackables.Services.Concrete
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductMapper _productMapper;

        public ProductServices()
        { }

        public ProductServices(IProductRepository productRepository, IProductMapper productMapper)
        {
            _productRepository = productRepository;
            _productMapper = productMapper;
        }

        public IEnumerable<Product> GetProducts(string userId)
        {
            DataTable dataTable = _productRepository.GetProducts(userId);
            return _productMapper.HydrateProducts(dataTable);
        }

        public IEnumerable<Product> GetProducts(string userId, List<Serving> servings)
        {
            DataTable dataTable = _productRepository.GetProducts(userId, servings);
            return _productMapper.HydrateProducts(dataTable);
        }

        public IEnumerable<Product> GetProducts(string userId, List<Day> days)
        {
            IEnumerable<Serving> servings = new List<Serving>();

            foreach (var day in days)
            {
                servings = servings.Concat(day.Food);
            }

            DataTable dataTable = _productRepository.GetProducts(userId, servings);
            return _productMapper.HydrateProducts(dataTable);
        }

        public IEnumerable<Product> GetProducts(string userId, Day day)
        {
            IEnumerable<Serving> servings = new List<Serving>();

            servings = servings.Concat(day.Food);

            DataTable dataTable = _productRepository.GetProducts(userId, servings);
            return _productMapper.HydrateProducts(dataTable);
        }

        public void CreateProduct(Product product, int userId)
        {
            _productRepository.CreateProduct(product, userId);
        }

        public void CreateProduct(Product product, string userId)
        {
            _productRepository.CreateProduct(product, userId);
        }

        public void UpdateProduct(string userId, Product product)
        {
            _productRepository.UpdateProduct(userId, product);
        }

        public Product GetProduct(string userId, string code)
        {
            DataTable dataTable = _productRepository.GetProduct(userId, code);
            return _productMapper.HydrateProducts(dataTable).FirstOrDefault();
        }

        public List<Product> GetCustomProducts(string userId)
        {
            DataTable dataTable = _productRepository.GetCustomProducts(userId);
            return _productMapper.HydrateProducts(dataTable).ToList();
        }

        public void DeleteProduct(string code)
        {
            _productRepository.DeleteProduct(code);
        }

        public Dictionary<string, decimal> GetNutrients(Product product)
        {
            var nutrients = new Dictionary<string, decimal>();

            foreach(ProductNutrient productNutrient in product.ProductMacronutrients.ProductNutrients)
            {
                nutrients.Add(productNutrient.Name, productNutrient.Quantity);
            }

            foreach (ProductNutrient productNutrient in product.ProductMicronutrients.ProductNutrients)
            {
                nutrients.Add(productNutrient.Name, productNutrient.Quantity);
            }

            return nutrients;
        }

        public Dictionary<string, decimal> GetMacroNutrients(Product product)
        {
            var nutrients = new Dictionary<string, decimal>();

            foreach (ProductNutrient productNutrient in product.ProductMacronutrients.ProductNutrients)
            {
                nutrients.Add(productNutrient.Name, productNutrient.Quantity);
            }

            return nutrients;
        }

        public Dictionary<string, decimal> GetMicroNutrients(Product product)
        {
            var nutrients = new Dictionary<string, decimal>();

            foreach (ProductNutrient productNutrient in product.ProductMicronutrients.ProductNutrients)
            {
                nutrients.Add(productNutrient.Name, productNutrient.Quantity);
            }

            return nutrients;
        }

        public ProductMacronutrients UpdateProductMacronutrients(Dictionary<string, decimal> nutrients)
        {
            var productMacronutrients = new ProductMacronutrients().InitialiseList();

            foreach (var key in nutrients.Keys)
            {               
                if (productMacronutrients.ProductNutrients.Exists(n => n.Name == key))
                    productMacronutrients.Update(key, nutrients[key]);
            }

            return productMacronutrients;
        }

        public ProductMicronutrients UpdateProductMicronutrients(Dictionary<string, decimal> nutrients)
        {
            var productMicronutrients = new ProductMicronutrients().InitialiseList();

            foreach (var key in nutrients.Keys)
            {
                if (productMicronutrients.ProductNutrients.Exists(n => n.Name == key))
                    productMicronutrients.Update(key, nutrients[key]);
            }

            return productMicronutrients;
        }
    }
}
