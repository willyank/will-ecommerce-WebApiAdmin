using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceModels
{
    [Table("categories")]
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
    }
}
