using Microsoft.EntityFrameworkCore;
using Action = Core.Entities.Action;

namespace Infrastructure.Persistance
{
    public class ActionDbContext : DbContext
    {
        public DbSet<Action> Actions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StringWorker;Integrated Security=True");
        }
    }
}
