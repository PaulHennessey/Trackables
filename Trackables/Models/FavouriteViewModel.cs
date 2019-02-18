using System.ComponentModel.DataAnnotations;

namespace MyFoodDiary.Models
{
    public class FavouriteViewModel
    {
        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}