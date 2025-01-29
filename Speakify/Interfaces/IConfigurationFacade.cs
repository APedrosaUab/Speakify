using Speakify.Interfaces;
using Speakify.Models;

namespace Speakify.Interfaces
{
    public interface IConfigurationFacade
    {
        List<IConfigurableParameter> GetConfigurableParameters();
    }
}