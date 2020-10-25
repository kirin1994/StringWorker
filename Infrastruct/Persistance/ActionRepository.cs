using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistance
{
    public class ActionRepository : IActionRepository
    {
        ActionDbContext _dbContext;

        public ActionRepository(ActionDbContext context)
        {
            _dbContext = context;
        }

        public void AddAction(string actionInfo, string input, string output)
        {
            _dbContext.Actions.Add(new Core.Entities.Action { Id = new Guid(), ActionInfo = actionInfo, Input = input, Output = output, ActionDate = DateTime.Now });
            _dbContext.SaveChanges();
        }
    }
}
