using LBS_API.Model;
using Microsoft.EntityFrameworkCore;

namespace LBS_API.DBContexts
{
    public class LoadContext : DbContext
    {
        public LoadContext(DbContextOptions<LoadContext> options) : base(options)
        {
        }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Unit> UnitTypes { get; set; }   
    }
}
