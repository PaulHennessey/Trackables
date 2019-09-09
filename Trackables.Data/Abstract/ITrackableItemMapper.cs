using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface ITrackableItemMapper
    {
        IEnumerable<TrackableItem> HydrateTrackableItems(DataTable dataTable);
        IEnumerable<ChartItem> HydrateTrackableItem(DataTable dataTable);
    }
}
