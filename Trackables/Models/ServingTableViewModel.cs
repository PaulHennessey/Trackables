using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trackables.Models
{
    public class ServingTableViewModel
    {
        public ServingTableViewModel()
        {
            Servings = new List<ServingViewModel>();
        }

        public IEnumerable<ServingViewModel> Servings { get; set; }
    }
}