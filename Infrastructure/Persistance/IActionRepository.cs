using Core.Entities;
using System.Collections.Generic;

namespace Infrastructure.Persistance
{
    public interface IActionRepository
    {
        void AddAction(string actionInfo, string input, string output);
    }
}
