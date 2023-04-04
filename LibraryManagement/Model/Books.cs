using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Model
{
    public class Books
    {
        [Key]
        public int BookItemId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BookItemName { get; set; }

        public decimal Price { get; set; }
    }
}
