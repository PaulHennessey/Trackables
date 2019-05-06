using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trackables.Models
{
    public class MealsTableViewModel
    {
        public MealsTableViewModel()
        {
            Meals = new List<MealViewModel>();
        }

        public IEnumerable<MealViewModel> Meals { get; set; }
    }
}