using System;
using System.Linq;

namespace Core.Plugins
{
    public class ReversePlugin : IPlugin, IPluginDescription
    {
        public string Description => "Plugin which reverses input and returns it.";

        public string Execute(string input)
        {
            _ = input ?? throw new ArgumentNullException("Input can't be null");

            return new string(input.Reverse().ToArray());
        }
    }
}
