using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementWebApiCore.Model
{
    public class IMG_CoreContext:DbContext
    {

        public IMG_CoreContext(DbContextOptions<IMG_CoreContext> options):base(options) { }

        public DbSet<Category> Categories { get; set; } 

        public DbSet<UserLogin> Users { get; set; }

    }
}
