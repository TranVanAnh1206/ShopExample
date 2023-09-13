using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopExample.Web.Models
{
    public class ProductTagViewModel
    {
        public long ProductID { get; set; }

        public string TagID { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public virtual TagViewModel Tag { get; set; }
    }
}