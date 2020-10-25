using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Action
    {
        public Guid Id { get; set; }
        public string ActionInfo { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
