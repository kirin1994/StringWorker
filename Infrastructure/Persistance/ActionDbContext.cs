using Microsoft.EntityFrameworkCore;
using Action = Core.Entities.Action;

namespace Infrastructure.Persistance
{
    public class ActionDbContext : DbContext
    {
        public DbSet<Action> Actions { get; set; }

        public ActionDbContext(DbContextOptions<ActionDbContext> options) :base(options) { } 

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}
    }
}
