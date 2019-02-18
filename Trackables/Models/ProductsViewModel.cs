using System.Collections.Generic;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}