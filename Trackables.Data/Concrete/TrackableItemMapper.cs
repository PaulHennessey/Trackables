
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
    }
}
