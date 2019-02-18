using MyFoodDiary.Domain;
using System.Collections.Generic;

namespace MyFoodDiary.Models
{
    public class ProductViewModel
    { 
        public string Code { get; set; }    
        public string Name { get; set; }
        public Dictionary<string, decimal> MacroNutrients { get; set; }
        public Dictionary<string, decimal> MicroNutrients { get; set; }
    }
}