using System.Collections.Generic;
using System.Web.Mvc;
using Trackables.Domain;
using System.Linq;

namespace Trackables.Models
{
    public class MacronutrientsViewModel
    {        
        public int SelectedNutrientId { get; set; }

        public IEnumerable<SelectListItem> Nutrients
        {
            get
            {
                // Clone the static list of macronutrients
                List<Nutrient> nutrients = Macronutrients.Nutrients.ToList();

                // Add a fake one for the ratios, the view uses this to build the drop down list
                nutrients.Add(new Nutrient { Id = 7, Name = "Macronutrient Ratios", MeasurementUnit = "%" });

                return new SelectList(nutrients, "Id", "Name");
            }
        }
    }
}