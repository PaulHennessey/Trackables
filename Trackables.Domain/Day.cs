using System;
using System.Collections.Generic;

namespace Trackables.Domain
{
    public class Day
    {
        public DateTime Date { get; set; }
        public List<FoodItem> Food { get; set; } 
    }
}
