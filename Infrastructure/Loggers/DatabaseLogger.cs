using Infrastructure.Loggers;
using Infrastructure.Persistance;

namespace Infrastructure.Loggers
{
    public class DatabaseLogger : IAppLogger
    {
        private IActionRepository _actionRepository;

        public DatabaseLogger(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        public void LogAction(string actionName, string input = "", string output = "")
        {
            _actionRepository.AddAction(actionName, input, output);
        }
    }
}
