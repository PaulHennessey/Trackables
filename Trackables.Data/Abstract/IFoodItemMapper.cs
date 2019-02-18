using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface IFoodItemMapper
    {
        IEnumerable<FoodItem> HydrateFoodItems(DataTable dataTable);
    }
}
