using Speakify.Interfaces;
using Speakify.Models;

namespace Speakify.Implementations
{
    public class ConfigurableParameterFactory : IParameterFactory
    {
        public IConfigurableParameter CreateParameter(string name, string type)
        {
            return type.ToLower() switch
            {
                "text/plain" => new TextParameter(name),
                "integer" => new IntegerParameter(name),
                "url" => new UrlParameter(name),
                _ => throw new ArgumentException("Tipo desconhecido", nameof(type))
            };
        }

        public IAnalytics CreateAnalytics(string name, string type)
        {
            return type.ToLower() switch
            {
                "quantitative" => new QuantitativeAnalytics(name),
                "qualitative" => new QualitativeAnalytics(name),
                _ => throw new ArgumentException("Tipo desconhecido", nameof(type))
            };
        }
    }
}
