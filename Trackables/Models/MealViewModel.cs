using Trackables.Domain;
using System.Collections.Generic;

namespace Trackables.Models
{
    public class MealViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public AutocompleteViewModel Autocomplete { get; set; }
    }

    public class SearchTypeAheadEntity
    {
        public string ShortCode { get; set; }
        public string Name { get; set; }
    }
}