
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopExample.Model.Model
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(501)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Url { get; set; }
        public int DisplayOrder { get; set; }
        public Guid GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual MenuGroup MenuGroup { get; set; }
        [Required]
        [MaxLength(10)]
        public string Target { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Static { get; set; }
    }
}
