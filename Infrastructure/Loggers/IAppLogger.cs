namespace Infrastructure.Loggers
{
    public interface IAppLogger
    {
        void LogAction(string actionName, string input = "", string output = "");
    }
}
