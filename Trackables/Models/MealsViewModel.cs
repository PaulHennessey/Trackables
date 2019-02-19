using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Models
{
    public class MealsViewModel
    {
        public IEnumerable<Meal> Meals { get; set; }
    }
}