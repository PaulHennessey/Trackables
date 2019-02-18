using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface IProductMapper
    {
        IEnumerable<Product> HydrateProducts(DataTable dataTable);
    }
}
