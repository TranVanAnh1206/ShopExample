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
    [Table("Sys_Status" )]
    public class Sys_Status : Auditable
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Status_Of { get; set; }

    }
}
