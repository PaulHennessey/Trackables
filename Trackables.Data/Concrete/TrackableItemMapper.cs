
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;
using Trackables.Domain.Extensions;

namespace Trackables.Data.Concrete
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

        public IEnumerable<ChartItem> HydrateTrackableItem(DataTable dataTable)
        {
            return from DataRow row in dataTable.Rows
                   select new ChartItem
                   {
                       Quantity = row.GetNullableDecimal("Quantity"),
                       Date = Convert.ToDateTime(row["Date"])
                   };
        }

        public IEnumerable<ChartItem> HydrateTrackable(DataTable dataTable)
        {
            return from DataRow row in dataTable.Rows
                   select new ChartItem
                   {
                       Quantity = row.GetNullableDecimal("Quantity"),
                       Date = Convert.ToDateTime(row["Date"])
                   };
        }

    }
}
