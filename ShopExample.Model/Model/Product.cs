using ShopExample.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ShopExample.Model.Model
{
    [Table("Products" )]
    public class Product : Auditable
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(501)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Contents { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(500)]
        public string Alias { get; set; }
        public Guid? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }
        [Column(TypeName = "varchar")]
        public string Image { get; set; }
        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }
        public bool HomeFlag { get; set; }
        public bool HotFlag { get; set; }
        public int ViewCount { get; set; }
        public int BuyCount { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        // public int? Warranty { get; set; } // Bảo hành - theo tháng
        public int ReviewCount { get; set; }
        //[MaxLength(500)]
        //public string Origin { get; set; }
        public string Tags { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }
    }
}
