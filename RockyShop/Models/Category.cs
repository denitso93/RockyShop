using System.ComponentModel.DataAnnotations;

namespace RockyShop.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage="Must be more than 0!!!")]
        public int DisplayOrder { get; set; }
    }
}
