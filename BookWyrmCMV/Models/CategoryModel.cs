using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWyrmCMV.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
