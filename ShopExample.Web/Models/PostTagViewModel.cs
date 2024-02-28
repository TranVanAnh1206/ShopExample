using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopExample.Web.Models
{
    public class PostTagViewModel
    {
        public Guid PostID { get; set; }

        public string TagID { get; set; }

        public virtual PostViewModel Post { get; set; }

        public virtual TagViewModel Tag { get; set; }
    }
}