using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public interface IActionAsyncRepository
    {
        Task<List<Action>> GetActionsAsync();
    }
}
