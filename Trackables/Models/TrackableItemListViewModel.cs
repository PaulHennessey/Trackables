using System.Collections.Generic;

namespace Trackables.Models
{
    public class TrackableItemListViewModel
    {
        public TrackableItemListViewModel()
        {
            TrackableItems = new List<TrackableItemViewModel>();
        }

        public IEnumerable<TrackableItemViewModel> TrackableItems { get; set; }
    }
}