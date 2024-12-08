using Speakify.Interfaces;

namespace Speakify.Implementations
{
    public class UrlParameter : IConfigurableParameter
    {
        public string Name { get; }
        public string Type { get; } = "URL";

        public UrlParameter(string name)
        {
            Name = name;
        }
    }
}
