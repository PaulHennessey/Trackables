using System.Collections.Generic;
using System.Web.Mvc;
using Trackables.Domain;

namespace Trackables.Models
{
    public class MicronutrientsViewModel
    {        
        public int SelectedNutrientId { get; set; }

        public IEnumerable<SelectListItem> Nutrients
        {
            get { return new SelectList(Micronutrients.Nutrients, "Id", "Name"); }
        }
    }
}