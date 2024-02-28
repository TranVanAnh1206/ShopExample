using ShopExample.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Model.Model
{
    [Table("Brands")]
    public class Brand : Auditable
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
