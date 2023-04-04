using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Model
{
    public class OrderMaster
    {
        [Key]
        public long OrderMasterId { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string OrderNumber { get; set; }

        public int StudentId { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string BMethod { get; set; }

        public string Purpose { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } 

        [NotMapped]
        public string DeletedOrderItemIds { get; set; }
    }
}
