using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Model.Model
{
    [Table("ProductDetails" )]
    public class ProductDetail
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public string Colors { get; set; }
        public string Sizes { get; set; }
        public int Rating { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        public string Other_Info { get; set; }
    }
}
