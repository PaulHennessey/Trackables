using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Models
{
    public class MacronutrientsViewModel
    {
        public MacronutrientsViewModel()
        {
            Macronutrients = new List<Nutrient>();
        }
        public IEnumerable<Nutrient> Macronutrients { get; set; }
    }
}