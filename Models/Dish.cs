using System;
using System.ComponentModel.DataAnnotations;


namespace delicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required(ErrorMessage = "Dish must have a name!")]
        [MinLength(4)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Dish must have a chef!")]
        [MinLength(3)]
        public string Chef { get; set; }
        [Required(ErrorMessage = "Dish must have a level of tastiness!")]
        public int Tastiness { get; set; }
        [Required(ErrorMessage = "Dish must have some calories!")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Must be greater than 0.")]
        public int Calories { get; set; }
        [Required(ErrorMessage = "Must tell us about the dish!")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}