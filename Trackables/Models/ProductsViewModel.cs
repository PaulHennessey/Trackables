using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}