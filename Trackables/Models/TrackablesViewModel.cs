using System.Collections.Generic;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Models
{
    public class TrackablesViewModel
    {
        public IEnumerable<Trackable> Trackables { get; set; }
    }
}