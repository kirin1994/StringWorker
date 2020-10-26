using Core.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActionsController : ControllerBase
    {
        private IActionAsyncRepository _actionRepository;
        public ActionsController(IActionAsyncRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        [HttpGet]
        public async Task<List<Action>> GetActions()
        {
            return await _actionRepository.GetActionsAsync();
        }
    }
}
