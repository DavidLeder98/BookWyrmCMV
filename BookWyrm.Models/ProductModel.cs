using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookWyrm.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(30)]
        public string ISBN { get; set; }
        [Required]
		[Range(1, 1000)]
		public double Price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
		[ValidateNever]
		public CategoryModel Category { get; set; }
		[ValidateNever]
		public string ImgUrl { get; set; }
    }
}
