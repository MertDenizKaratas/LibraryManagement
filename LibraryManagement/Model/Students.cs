using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Model
{
    public class Students
    {
        [Key]
        public int StudentID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string StudentName { get; set; }
    }
}

