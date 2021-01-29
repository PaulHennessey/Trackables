using System.Collections.Generic;

namespace Trackables.Models
{
    public class CaloriesFirstServingListViewModel
    {
        public IEnumerable<CaloriesFirstServingViewModel> Servings { get; set; }
        public IEnumerable<FavouriteViewModel> Favourites { get; set; }      
        public decimal TotalCalories { get; set; }
    }
}