using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Model.Model
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        public Guid ParentID { get; set; }
        [Required]
        public Guid ProductID { get; set; }
        [Required]
        public string UserID { get; set; }
        public string Subject { get; set; } = "Đánh giá sản phẩm";
        [Required]
        public string Message { get; set; }
        [Required]
        public int Rating { get; set; }
        public int Likes { get; set; } = 0;
        public string Images { get; set; }
        public string Videos { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [MaxLength(500)]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTime? ModifiedDate { get; set; }

    }
}
