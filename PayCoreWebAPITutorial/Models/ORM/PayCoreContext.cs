using Microsoft.EntityFrameworkCore;

namespace PayCoreWebAPITutorial.Models.ORM
{
    public class PayCoreContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EET2RGT; Database=PayCoreDB; trusted_connection=true");
        }

        public DbSet<Product> Products { get; set; }

    }
}
