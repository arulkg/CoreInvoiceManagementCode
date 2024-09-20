using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class IMGCoreDbContext:DbContext
    {
        public IMGCoreDbContext(DbContextOptions<IMGCoreDbContext> options) : base(options) { }

        public DbSet<CategoryObj> Categories { get; set; }
        public DbSet<UserLoginObj> Users { get; set; }

    }
}
