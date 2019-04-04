using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trackables.Models
{
    public class FoodLogViewModel
    {
        public FoodLogViewModel()
        {
            FoodItems = new List<FoodItemViewModel>();
        }

        public IEnumerable<FoodItemViewModel> FoodItems { get; set; }
    }
}