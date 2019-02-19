using Trackables.Domain;
using System.Collections.Generic;

namespace Trackables.Models
{
    public class ProductViewModel
    { 
        public string Code { get; set; }    
        public string Name { get; set; }
        public Dictionary<string, decimal> MacroNutrients { get; set; }
        public Dictionary<string, decimal> MicroNutrients { get; set; }
    }
}