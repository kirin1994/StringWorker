using Core.Plugins;
using Infrastructure.Loggers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class ConsoleInterface
    {
        private List<Type> _plugins;
        private IAppLogger _logger;

        public ConsoleInterface(List<Type> plugins, IAppLogger logger)
        {
            _plugins = plugins;
            _logger = logger;
        }

        public void DisplayStartScreen()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------String Worker-----------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("- To check available plugins press 1");
            Console.WriteLine("- Choose Plugin press 2");
            Console.WriteLine("- Interpreter mode press 3");
            Console.WriteLine("- End program press 0");
            Console.WriteLine(" ");
        }

        private Type ChoosePlugin()
        {
            Console.WriteLine("Write plugin name, and press ENTER.");
            Console.WriteLine(" ");

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    var plugin = _plugins.FirstOrDefault(p => p.Name.ToLower() == input.ToLower());
                    if (plugin != null)
                    {
                        return plugin;
                    }

                    Console.WriteLine("Given plugin does not exist. Try again.");
                    Console.WriteLine(" ");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorect format of given mode. Try again.");
                    Console.WriteLine(" ");
                }
            }
        }

        private void DisplayAvailablePlugins()
        {
            Console.WriteLine("Available Plugins");
            Console.WriteLine(" ");

            foreach (var plugin in _plugins)
            {
                Console.WriteLine($" Plugin Name: { plugin.Name}");
                var description = typeof(IPluginDescription).IsAssignableFrom(plugin) ? ((IPluginDescription)Activator.CreateInstance(plugin)).Description : "Description missing.";
                Console.WriteLine($" Description: {description}");
                Console.WriteLine(" ");
            }
            _logger.LogAction("Available  plugins listed");
        }

        public static bool ShouldAddPluginsAsSingletons()
        {
            Console.WriteLine("If you want to register plugins as singletones click 'y', in other case click different letter.");
            Console.WriteLine(" ");
            if (Console.ReadKey().KeyChar == 'y')
            {
                return true;
            }
            return false;
        }

        private void PluginMode(Type plugin)
        {
            Console.WriteLine($"Chosen plugin: {plugin.Name}");
            Console.WriteLine("If you want to go back on main menu type 'exit' and press ENTER.");

            while (true)
            {
                Console.WriteLine("Write input data and confirm with ENTER button.");
                var input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;

                var service = ServiceManager.GetPluginService(plugin);

                Console.WriteLine(" ");
                var output = service.Execute(input);
                Console.WriteLine($"Output: {output}");
                Console.WriteLine(" ");
                _logger.LogAction(plugin.Name, input, output);
            }
        }


        public void InterpreterMode()
        {
            _logger.LogAction("Interpreter Mode chosen");
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------Interpreter Mode---------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Syntax: PluginName InputData");
            Console.WriteLine("Example: SumPlugin 12+14+16");
            Console.WriteLine("To turn off, type 'exit' and press ENTER.");
            Console.WriteLine(" ");

            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Split(' ');

                    if (input[0].ToLower() == "exit")
                        break;

                    if (input.Length == 2)
                    {
                        var plugin = _plugins.FirstOrDefault(p => p.Name.ToLower() == input[0].ToLower());
                        if (plugin != null)
                        {
                            var service = ServiceManager.GetPluginService(plugin);
                            var output = service.Execute(input[1]);
                            Console.WriteLine($">> {output}");
                            _logger.LogAction($"Used plugin: {(input[0])}", input[1], output);
                        }
                        else
                        {
                            Console.WriteLine("Given plugin does not exist. Try again.");
                            Console.WriteLine(" ");
                            _logger.LogAction($"Wrong plugin chosen({input[0]})");
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorect format of input data. Try again.");
                    Console.WriteLine(" ");
                    _logger.LogAction("Inserted incorect format of input data");
                }
            }

        }

        public void ChooseMode()
        {
            Console.Clear();
            while (true)
            {
                DisplayStartScreen();
                Console.WriteLine("Choose an option (type option number)");
                Console.WriteLine(" ");

                try
                {
                    var input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 0:
                            _logger.LogAction("Application closed");
                            Environment.Exit(0);
                            break;
                        case 1:
                            DisplayAvailablePlugins();
                            break;
                        case 2:
                            var plugin = ChoosePlugin();
                            PluginMode(plugin);
                            break;
                        case 3:
                            InterpreterMode();
                            break;
                        default:
                            Console.WriteLine("Given mode does not exist. Try again.");
                            Console.WriteLine(" ");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorect format of given mode. Try again.");
                    Console.WriteLine(" ");
                }
            }
        }
    }
}
