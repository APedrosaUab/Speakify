using Speakify.Interfaces;

namespace Speakify.Implementations
{
    public class QuantitativeAnalytics : IAnalytics
    {
        public string Name { get; }
        public string Type { get; } = "quantitative";

        public QuantitativeAnalytics(string name)
        {
            Name = name;
        }
    }
}
