using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopExample.Web.Models
{
    public class ProductCategoryViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public Guid? ParentID { get; set; }
        public string Image { get; set; }
        public int? DisplayOrder { get; set; }
        public bool HomeFlag { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public int Status { get; set; }
    }
}