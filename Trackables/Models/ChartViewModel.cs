using System.Collections.Generic;
using System.Web.Mvc;
using Trackables.Domain;

namespace Trackables.Models
{
    public class ChartViewModel
    {
        public List<string> ChartTitle { get; set; }
        public List<string> BarNames { get; set; }
        public List<List<decimal>> BarData { get; set; }
    }
}