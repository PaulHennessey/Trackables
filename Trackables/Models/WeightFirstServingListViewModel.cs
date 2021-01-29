using System.Collections.Generic;

namespace Trackables.Models
{
    public class WeightFirstServingListViewModel
    {
        public IEnumerable<WeightFirstServingViewModel> Servings { get; set; }
        public IEnumerable<FavouriteViewModel> Favourites { get; set; }
        public IEnumerable<MealViewModel> Meals { get; set; }
        public decimal TotalCalories { get; set; }
    }
}