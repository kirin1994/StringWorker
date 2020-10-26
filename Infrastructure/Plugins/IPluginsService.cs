using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Infrastructure.Plugins
{
    public interface IPluginsService
    {
        public static IPluginsService Instance { get; }
        void AddPlugins(IServiceCollection services, bool AddAsSingletone);
        List<Type> GetAvailablePluginsTypes();
        List<Type> DiscoverPlugins();
    }
}