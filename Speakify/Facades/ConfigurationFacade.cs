using Speakify.Interfaces;
using Speakify.Models;

namespace Speakify.Facades
{
    public class ConfigurationFacade : IConfigurationFacade
    {
        private readonly IParameterFactory _parameterFactory;

        public ConfigurationFacade(IParameterFactory parameterFactory)
        {
            _parameterFactory = parameterFactory;
        }

        // Função para obter parâmetros configuráveis
        public List<IConfigurableParameter> GetConfigurableParameters()
        {
            return new List<IConfigurableParameter>
            {
                _parameterFactory.CreateParameter("tipo_exercicio", "text/plain"),
                _parameterFactory.CreateParameter("nivel_dificuldade", "integer"),
                _parameterFactory.CreateParameter("objetivo_atividade", "text/plain"),
                _parameterFactory.CreateParameter("tempo_estimado", "integer"),
                _parameterFactory.CreateParameter("instrucoes_exercicio", "text/plain"),
                _parameterFactory.CreateParameter("numero_questoes", "integer"),
                _parameterFactory.CreateParameter("link_material_apoio", "URL")
            };
        }
    }
}