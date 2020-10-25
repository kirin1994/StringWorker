using System;

namespace Core.Plugins
{
    public class CountPlugin : IPlugin, IPluginDescription
    {
        public string Description => "Plugin which counts characters in input string and returns the number as string.";

        public string Execute(string input) 
        {
            _ = input ?? throw new ArgumentNullException("Input can't be null");
                
            return input.Length.ToString();
        }
    }
}
