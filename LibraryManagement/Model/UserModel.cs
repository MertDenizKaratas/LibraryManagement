using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Model
{
    public class UserModel
    {
        [Key]
        public int StudentID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public string StudentName { get; set; }
    }
}
