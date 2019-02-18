using System;
using System.Collections.Generic;

namespace MyFoodDiary.Domain
{
    public class Day
    {
        public DateTime Date { get; set; }
        public List<FoodItem> Food { get; set; } 
    }
}
