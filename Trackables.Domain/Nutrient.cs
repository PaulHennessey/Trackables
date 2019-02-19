using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackables.Domain
{
    public class Nutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeasurementUnit { get; set; }
        public decimal RDA { get; set; }
    }
}
