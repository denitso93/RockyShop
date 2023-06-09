﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockyShop.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range( 1, int.MaxValue )]
        public double Price { get; set; }
        public string Image { get; set; }


        [Display(Name="Category Type")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category CategoryId { get; set; }
    }
}
