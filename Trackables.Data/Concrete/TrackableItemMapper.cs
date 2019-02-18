
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;
using MyFoodDiary.Domain.Extensions;

namespace MyFoodDiary.Data.Concrete
{
    public class TrackableItemMapper : ITrackableItemMapper
    {
        public IEnumerable<TrackableItem> HydrateTrackableItems(DataTable dataTable)
        {
            return from DataRow row in dataTable.Rows
                   select new TrackableItem
                   {
                       Id = row.GetNullableInt("Id"),
                       TrackableId = Convert.ToInt32(row["TrackableId"]),
                       Name = row["Name"].ToString(),
                       Quantity = row.GetNullableDecimal("Quantity")
                   };
        }
    }
}
