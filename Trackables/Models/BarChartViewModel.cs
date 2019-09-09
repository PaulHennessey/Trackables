using System.Collections.Generic;
using System.Web.Mvc;
using Trackables.Domain;

namespace Trackables.Models
{
    public class BarChartViewModel
    {
        public BarChartViewModel()
        {
            ChartTitle = new List<string>();
            BarNames = new List<string>();
            BarData = new List<List<decimal?>>();
        }
        public List<string> ChartTitle { get; set; }
        public List<string> BarNames { get; set; }
        public List<List<decimal?>> BarData { get; set; }
    }
}