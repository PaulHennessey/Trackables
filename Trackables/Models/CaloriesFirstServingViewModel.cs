using System.ComponentModel.DataAnnotations;

namespace Trackables.Models
{
    public class CaloriesFirstServingViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Calories { get; set; }
    }
}