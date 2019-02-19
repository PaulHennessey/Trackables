using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IFoodItemMapper
    {
        IEnumerable<FoodItem> HydrateFoodItems(DataTable dataTable);
    }
}
