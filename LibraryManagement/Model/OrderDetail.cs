using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Model
{
    public class OrderDetail
    {
        [Key]
        public long OrderDetailId { get; set; }

        public long OrderMasterId { get; set; }

        public int BookItemId { get; set; }

        public decimal BookItemPrice { get; set; }

        public int Quantity { get; set; }
    }
}
