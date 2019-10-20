using System.Collections.Generic;
using System.Web.Mvc;
using Trackables.Domain;
using System.Linq;

namespace Trackables.Models
{
    public class ChartTypeDropDownListViewModel
    {        
        public int ChartTypeId { get; set; }

        public IEnumerable<SelectListItem> Types
        {
            get
            {
                // Clone the static list of charttypes
                List<ChartType> chartTypes = ChartTypes.Types.ToList();

                return new SelectList(chartTypes, "Id", "Name");
            }
        }
    }
}