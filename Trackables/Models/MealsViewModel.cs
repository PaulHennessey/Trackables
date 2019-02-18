using System.Collections.Generic;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Models
{
    public class MealsViewModel
    {
        public IEnumerable<Meal> Meals { get; set; }
    }
}