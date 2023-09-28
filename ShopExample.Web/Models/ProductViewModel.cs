using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopExample.Web.Models
{
    public class ProductViewModel
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Contents { get; set; }

        public string Alias { get; set; }

        public long CategoryID { get; set; }

        public string Image { get; set; }

        public string MoreImage { get; set; }

        public bool HomeFlag { get; set; }

        public bool HotFlag { get; set; }

        public int ViewCount { get; set; }

        public int BuyCount { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal PromotionPrice { get; set; }

        public int Warranty { get; set; } // Bảo hành - theo tháng

        public int ReviewCount { get; set; }

        public string Origin { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string MetaKeyWord { get; set; }

        public string MetaDescription { get; set; }

        public bool Status { get; set; }

        public string Tags { get; set; }
        public virtual IEnumerable<ProductTagViewModel> ProductTags { get; set; }
    }
}