using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LibraryManagement.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderMaster> OrderMaster { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
