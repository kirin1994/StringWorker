using Infrastructure;
using Infrastructure.Plugins;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var availablePlugins = PluginsService.Instance.GetAvailablePluginsTypes();
            _ = new ServiceManager();
            var consoleInterface = new ConsoleInterface(availablePlugins, ServiceManager.GetLogger());
            consoleInterface.DisplayStartScreen();
            consoleInterface.ChooseMode();
        }
    }
}
