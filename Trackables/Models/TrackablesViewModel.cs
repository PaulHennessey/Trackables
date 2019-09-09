using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Models
{
    public class TrackablesViewModel
    {
        public TrackablesViewModel()
        {
            Trackables = new List<Trackable>();
        }
        public IEnumerable<Trackable> Trackables { get; set; }
     //   public IEnumerable<Nutrient> Macronutrients { get; set; }
    }
}