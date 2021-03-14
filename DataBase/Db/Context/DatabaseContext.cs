
using Microsoft.EntityFrameworkCore;
using Model;

namespace Database.Db.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Item> itemsDbSet { get; set; }
        public DbSet<Order> ordersDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Main.db");
        }
    }
}