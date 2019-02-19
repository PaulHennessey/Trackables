using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IProductMapper
    {
        IEnumerable<Product> HydrateProducts(DataTable dataTable);
    }
}
