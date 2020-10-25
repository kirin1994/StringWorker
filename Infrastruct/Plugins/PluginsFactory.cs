using Core.Plugins;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Infrastructure.Plugins
{
    public class PluginsFactory
    {
        private static List<Type> _plugins = new List<Type>();
        
       private static PluginsFactory pluginsFactory = new PluginsFactory();

        private PluginsFactory()
        {
            foreach (var type in typeof(IPlugin).Assembly.GetTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    _plugins.Add(type);
                }
            }
        }
        
        public static void AddPlugins(IServiceCollection services, bool AddAsSingletone)
        {
            if (AddAsSingletone)
                _plugins.ForEach(plugin => services.AddSingleton(typeof(IPlugin), plugin));
            else
                _plugins.ForEach(plugin => services.AddTransient(typeof(IPlugin), plugin));
        }

        public static List<Type> GetAvailablePluginsTypes()
        {
            return _plugins;
        }
    }
}
