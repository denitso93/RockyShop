using System.ComponentModel.DataAnnotations;

namespace RockyShop.Models
{
    public class ApplicationType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
