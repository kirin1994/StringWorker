using Core.Plugins;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Infrastructure.Plugins
{
    public class PluginsService : IPluginsService
    {
        private static List<Type> _plugins = new List<Type>();

        public static PluginsService Instance = new PluginsService();

        private PluginsService()
        {
            _plugins = DiscoverPlugins();
        }

        public void AddPlugins(IServiceCollection services, bool AddAsSingletone)
        {
            if (AddAsSingletone)
                _plugins.ForEach(plugin => services.AddSingleton(typeof(IPlugin), plugin));
            else
                _plugins.ForEach(plugin => services.AddTransient(typeof(IPlugin), plugin));
        }

        public List<Type> GetAvailablePluginsTypes()
        {
            return _plugins;
        }

        public List<Type> DiscoverPlugins()
        {
            List<Type> plugins = new List<Type>();
            foreach (var type in typeof(IPlugin).Assembly.GetTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    plugins.Add(type);
                }
            }

            return plugins;
        }
    }
}
