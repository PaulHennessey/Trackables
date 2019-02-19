using System.Collections.Generic;

namespace Trackables.Models
{
    public class CaloriesFirstFoodItemListViewModel
    {
        public IEnumerable<CaloriesFirstFoodItemViewModel> FoodItems { get; set; }
        public IEnumerable<FavouriteViewModel> Favourites { get; set; }      
        public decimal TotalCalories { get; set; }
    }
}