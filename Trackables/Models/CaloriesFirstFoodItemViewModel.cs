using System.ComponentModel.DataAnnotations;

namespace MyFoodDiary.Models
{
    public class CaloriesFirstFoodItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Calories { get; set; }
    }
}