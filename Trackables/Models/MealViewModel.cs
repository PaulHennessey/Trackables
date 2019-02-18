using MyFoodDiary.Domain;
using System.Collections.Generic;

namespace MyFoodDiary.Models
{
    public class MealViewModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}