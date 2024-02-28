using ShopExample.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopExample.Model.Model
{
    [Table("Slides" )]
    public class Slide : Auditable
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(501)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Image { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        [MaxLength(256)]
        public string Url { get; set; }

    }
}
