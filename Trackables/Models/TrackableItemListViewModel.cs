using System.Collections.Generic;

namespace MyFoodDiary.Models
{
    public class TrackableItemListViewModel
    {
        public IEnumerable<TrackableItemViewModel> TrackableItems { get; set; }
    }
}