using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Concrete
{
    public class FoodItemMapper : IFoodItemMapper
    {
        public IEnumerable<FoodItem> HydrateFoodItems(DataTable dataTable)
        {
            return from DataRow row in dataTable.Rows
                   select new FoodItem
                   {
                       Id = Convert.ToInt32(row["Id"]),
                       Code = row["Code"].ToString(),
                       Name = row["Name"].ToString(),
                       Quantity = Convert.ToInt32(row["Quantity"]),
                       Date = Convert.ToDateTime(row["Date"]),
                   };
        }
    }
}
