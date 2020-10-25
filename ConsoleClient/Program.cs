using Infrastructure;
using Infrastructure.Plugins;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var availablePlugins = PluginsFactory.GetAvailablePluginsTypes();
            _ = new ServiceManager();
            var consoleInterface = new ConsoleInterface(availablePlugins, ServiceManager.GetLogger());
            consoleInterface.DisplayStartScreen();
            consoleInterface.ChooseMode();
        }
    }
}
