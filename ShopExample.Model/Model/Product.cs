﻿using ShopExample.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ShopExample.Model.Model
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(501)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Contents { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(500)]
        public string Alias { get; set; }

        public long CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        [DefaultValue(true)]
        public bool HomeFlag { get; set; }

        [DefaultValue(true)]
        public bool HotFlag { get; set; }

        [DefaultValue(0)]
        public int ViewCount { get; set; }

        [DefaultValue(0)]
        public int BuyCount { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warranty { get; set; } // Bảo hành - theo tháng

        [DefaultValue(0)]
        public int ReviewCount { get; set; }

        [MaxLength(500)]
        public string Origin { get; set; }

        public IEnumerable<ProductTag> ProductTags { get; set; }
    }
}