using AspNetCoreServerSide.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreServerSide
{
    public class Fingers10DbContext:DbContext
    {
        public Fingers10DbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<DemoEntity> Demos { get; set; }
    }
}
