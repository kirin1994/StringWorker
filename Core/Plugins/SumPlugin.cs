using System;
using System.Linq;

namespace Core.Plugins
{
    public class SumPlugin : IPlugin, IPluginDescription
    {
        public string Description => "Plugin which splits string by ‘+’ sign, parses number, calculates sum of them and returns it as a string.";

        public string Execute(string input)
        {
            _ = input ?? throw new ArgumentNullException("Input can't be null.");
            var output = "";

            try {
                output = input.Split('+').Select(numb => int.Parse(numb)).Sum().ToString();
            } catch (FormatException)
            {
                throw new ArgumentException("Input should contain only numbers splited with + mark.");
            }

            return output;
        }
    }
}
