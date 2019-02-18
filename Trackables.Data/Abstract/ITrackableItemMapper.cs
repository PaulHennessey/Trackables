using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface ITrackableItemMapper
    {
        IEnumerable<TrackableItem> HydrateTrackableItems(DataTable dataTable);
    }
}
