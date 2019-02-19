using System.ComponentModel.DataAnnotations;

namespace Trackables.Models
{
    public class TrackableItemViewModel
    {
        public int? Id { get; set; }
        public int TrackableId { get; set; }
        public string Name { get; set; }
        public decimal? Quantity { get; set; }
    }
}