using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trackables.Models
{
    public class FoodItemTableViewModel
    {
        public FoodItemTableViewModel()
        {
            FoodItems = new List<FoodItemViewModel>();
        }

        public IEnumerable<FoodItemViewModel> FoodItems { get; set; }
    }
}