using Core.Plugins;
using Infrastructure.Loggers;
using Infrastructure.Persistance;
using Infrastructure.Plugins;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Infrastructure
{
    public class ServiceManager
    {
        private IServiceCollection _services;
        public static ServiceProvider ServiceProvider;

        public ServiceManager()
        {
            _services = new ServiceCollection();
            var addPluginsAsSingletones = ConsoleInterface.ShouldAddPluginsAsSingletons();
            PluginsFactory.AddPlugins(_services, addPluginsAsSingletones);
            _services.AddDbContext<ActionDbContext>();
            _services.AddSingleton<IActionRepository, ActionRepository>();
            _services.AddSingleton<IAppLogger, DatabaseLogger>();
            ServiceProvider = _services.BuildServiceProvider();
        }

        public static IAppLogger GetLogger()
        {
            return ServiceProvider.GetService<IAppLogger>();
        }

        public static IPlugin GetPluginService(Type type)
        {
            return ServiceProvider.GetServices<IPlugin>().FirstOrDefault(s => s.GetType() == type);             
        }

    }
}
