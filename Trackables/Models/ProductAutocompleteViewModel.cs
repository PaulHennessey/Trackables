namespace Trackables.Models
{
    public class ProductAutocompleteViewModel
    {
        public ProductAutocompleteViewModel()
        { }

        public ProductAutocompleteViewModel(string description, string id)
        {
            label = description;
            value = id;
        }

        public string value { get; set; }
        public string label { get; set; }
    }
}