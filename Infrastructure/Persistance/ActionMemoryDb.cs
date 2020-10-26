using Core.Entities;
using System;
using System.Collections.Generic;
using Action = Core.Entities.Action;

namespace Infrastructure.Persistance
{
    public class ActionMemoryDb
    {
        public static List<Action> GetTestActions()
        {
            return new List<Action>
            {
                new Action {ActionDate = new DateTime(), ActionInfo = "Action 1", Id = new Guid(), Input = "Input1", Output = "Output1"},
                new Action {ActionDate = new DateTime(), ActionInfo = "Action 2", Id = new Guid(), Input = "Input2", Output = "Output2"},
                new Action {ActionDate = new DateTime(), ActionInfo = "Action 3", Id = new Guid(), Input = "Input3", Output = "Output3"},
                new Action {ActionDate = new DateTime(), ActionInfo = "Action 4", Id = new Guid(), Input = "Input4", Output = "Output4"},
            };
        }
    }
}
