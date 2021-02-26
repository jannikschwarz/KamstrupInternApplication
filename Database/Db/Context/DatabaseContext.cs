using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Db.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Item> itemsDbSet { get; set; }
        public DbSet<Order> ordersDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = A:\Rider\Projects\InternApplication\Database\Main.db");
        }
    }
}