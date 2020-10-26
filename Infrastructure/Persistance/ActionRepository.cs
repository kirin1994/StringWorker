
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Action = Core.Entities.Action;

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

        public List<Core.Entities.Action> GetActions()
        {
            return _dbContext.Actions.ToList();
        }

        public void AddActions(List<Action> actions)
        {
            _dbContext.Actions.AddRange(actions);
            _dbContext.SaveChanges();
        }
    }
}
