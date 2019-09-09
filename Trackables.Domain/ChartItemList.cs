using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trackables.Domain
{
    public class ChartItemList
    {
        public ChartItemList()
        {
            ChartItems = new List<ChartItem>();
        }
        public List<ChartItem> ChartItems { get; set; }
        public string Name { get; set; }
    }
}