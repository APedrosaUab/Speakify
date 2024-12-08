using Speakify.Interfaces;

namespace Speakify.Implementations
{
    public class TextParameter : IConfigurableParameter
    {
        public string Name { get; }
        public string Type { get; } = "text/plain";

        public TextParameter(string name)
        {
            Name = name;
        }
    }
}
