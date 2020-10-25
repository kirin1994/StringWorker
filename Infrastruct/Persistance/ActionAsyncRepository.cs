using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class ActionAsyncRepository : IActionAsyncRepository
    {
        ActionDbContext _dbContext;

        public ActionAsyncRepository(ActionDbContext context)
        {
            _dbContext = context;
        }

        public Task<List<Core.Entities.Action>> GetActionsAsync()
        {
            return _dbContext.Actions.ToListAsync();
        }
    }
}
