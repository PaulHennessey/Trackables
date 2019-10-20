using System.Collections.Generic;
using System.Linq;

namespace Trackables.Domain
{
    public static class ChartTypes
    {
        public static List<ChartType> Types = new List<ChartType>
        {
            new ChartType { Id = 1, Name = "Bar" },
            new ChartType { Id = 2, Name = "Column" },
            new ChartType { Id = 3, Name = "Line" }
        };

        public static ChartType ChartType(string name)
        {
            return Types.Where(m => m.Name == name).First();
        }
    }
}
