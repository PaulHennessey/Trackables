using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Concrete
{
    public class FavouriteMapper : IFavouriteMapper
    {
        public IEnumerable<Favourite> HydrateFavourites(DataTable dataTable)
        {
            return from DataRow row in dataTable.Rows
                   select new Favourite
                   {
                       Code = row["Code"].ToString(),
                       Name = row["Name"].ToString(),
                       Quantity = Convert.ToInt32(row["Quantity"]),
                   };
        }
    }
}
