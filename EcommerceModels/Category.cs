using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceModels
{
    [Table("categories")]
    public class Category : BaseModel
    {
        [MinLength(length: 3)]
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
    }
}
