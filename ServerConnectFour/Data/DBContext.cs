using Microsoft.EntityFrameworkCore;
using ServerConnectFour.Models;

namespace ServerConnectFour.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<ServerConnectFour.Models.User>? Users { get; set; }
        public DbSet<ServerConnectFour.Models.Game>? Games { get; set; }


    }
}
