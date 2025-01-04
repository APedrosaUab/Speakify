﻿using Speakify.Interfaces;
using Speakify.Models;

namespace Speakify.Facades
{
    public class ConfigurationFacade
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

        // Função para gerar página de configuração em HTML
        public string GetConfigurationPageHtml()
        {
            return "<!DOCTYPE html>" +
                   "<html>" +
                   "<head>" +
                   "<meta charset='UTF-8'>" +
                   "<title>Speak!fy: improve your language skills</title>" +
                   "</head>" +
                   "<body>" +
                   "<h1>Configuracao de Atividade Inven!ra: Speak!fy</h1>" +
                   "<form>" +
                   "<div style='height: 50px;width: 500px;display: flex;'>" +
                   "<label style='width: 150px;display: inline-block; height: 30px;'>Tipo de Exercicio:</label>" +
                   "<select name='tipo_exercicio' style='height: 30px;width: 200px;'>" +
                   "<option value='gramatica'>Gramatica</option>" +
                   "<option value='vocabulario'>Vocabulario</option>" +
                   "<option value='conversacao'>Conversacao</option>" +
                   "</select>" +
                   "</div>" +
                   "<div style='height: 50px;width: 500px;display: flex;'>" +
                   "<label style='width: 150px;display: inline-block; height: 30px;'>Nivel de Dificuldade:</label>" +
                   "<input type='number' name='nivel_dificuldade' style='height: 30px;width: 200px;' min='1' max='5'/>" +
                   "</div>" +
                   "<div style='height: 50px;width: 500px;display: flex;'>" +
                   "<label style='width: 150px;display: inline-block; height: 30px;'>Objetivo da Atividade:</label>" +
                   "<input type='text' name='objetivo_atividade' style='height: 30px;width: 200px;'/>" +
                   "</div>" +
                   "<div style='height: 50px;width: 500px;display: flex;'>" +
                   "<label style='width: 150px;display: inline-block; height: 30px;'>Tempo Estimado (minutos):</label>" +
                   "<input type='number' name='tempo_estimado' style='height: 30px;width: 200px;'/>" +
                   "</div>" +
                   "<div style='height: 50px;min-width: 500px;display: flex;'>" +
                   "<label style='width: 150px;display: inline-block; height: 30px;'>Instrucoes:</label>" +
                   "<textarea name='instrucoes_exercicio' style='height: 30px;min-width: 200px; max-height: 40px;'></textarea>" +
                   "</div>" +
                   "<div style='height: 50px;width: 500px;display: flex;'>" +
                   "<label style='width: 150px;display: inline-block; height: 30px;'>Numero de Questoes:</label>" +
                   "<input type='number' name='numero_questoes' style='height: 30px;width: 200px;'/>" +
                   "</div>" +
                   "<div style='height: 50px;width: 500px;display: flex;'>" +
                   "<label style='width: 150px;display: inline-block; height: 30px;'>Material de Apoio:</label>" +
                   "<input type='url' name='link_material_apoio' style='height: 30px;width: 200px;'/>" +
                   "</div>" +
                   "</form>" +
                   "</body>" +
                   "</html>";
        }
    }
}
