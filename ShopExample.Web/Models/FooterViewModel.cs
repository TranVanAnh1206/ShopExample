using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopExample.Web.Models
{
    public class FooterViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Contents { get; set; }
    }
}