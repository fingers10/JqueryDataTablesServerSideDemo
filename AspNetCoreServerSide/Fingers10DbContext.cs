using AspNetCoreServerSide.Helpers;
using AspNetCoreServerSide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreServerSide
{
    public class Fingers10DbContext : DbContext
    {
        public Fingers10DbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<DemoEntity> Demos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<Position, string>(
                v => EnumHelper<Position>.GetDisplayValue(v),
                v => EnumHelper<Position>.Parse(v.Trim().Replace(" ", string.Empty)));
        }
    }
}
