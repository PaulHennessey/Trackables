using System.Collections.Generic;

namespace Trackables.Models
{
    public class ServingListViewModel
    {
        public IEnumerable<ServingViewModel> Servings { get; set; }
        public IEnumerable<FavouriteViewModel> Favourites { get; set; }      
    }
}