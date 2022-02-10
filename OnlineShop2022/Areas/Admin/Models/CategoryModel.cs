using System.ComponentModel.DataAnnotations;

namespace OnlineShop2022.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

