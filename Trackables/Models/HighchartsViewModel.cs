using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Models
{
    public class HighchartsViewModel
    {
        public HighchartsViewModel()
        {
            Categories = new List<string>();
            Series = new List<Series>();
        }
        public List<string> Categories { get; set; }
        public List<Series> Series { get; set; }
        public string Title { get; set; }

    }
}