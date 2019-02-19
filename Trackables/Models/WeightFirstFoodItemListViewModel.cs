using System.Collections.Generic;

namespace Trackables.Models
{
    public class WeightFirstFoodItemListViewModel
    {
        public IEnumerable<WeightFirstFoodItemViewModel> FoodItems { get; set; }
        public IEnumerable<FavouriteViewModel> Favourites { get; set; }
        public IEnumerable<MealViewModel> Meals { get; set; }
        public decimal TotalCalories { get; set; }
    }
}