using Microsoft.AspNetCore.Mvc;
using Speakify.Interfaces;
using Speakify.Implementations;
using System.Collections.Generic;

[ApiController]
[Route("api/ap-configuration")]
public class APConfigurationController : ControllerBase
{
    private readonly IParameterFactory _parameterFactory;

    public APConfigurationController()
    {
        _parameterFactory = new ConfigurableParameterFactory();
    }

    /// <summary>
    /// Retorna a página de configuração da atividade (HTML).
    /// </summary>
    [HttpGet("config_url")]
    public ActionResult GetConfigurationPage()
    {
        string htmlContent = "<!DOCTYPE html>" +
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
        return Content(htmlContent, "text/html; charset=utf-8");
    }

    /// <summary>
    /// Retorna os parâmetros configuráveis no formato JSON, usando Factory Method.
    /// </summary>
    [HttpGet("json_params_url")]
    public IActionResult GetJsonParams()
    {
        var parameters = new List<IConfigurableParameter>
        {
            _parameterFactory.CreateParameter("tipo_exercicio", "text/plain"),
            _parameterFactory.CreateParameter("nivel_dificuldade", "integer"),
            _parameterFactory.CreateParameter("objetivo_atividade", "text/plain"),
            _parameterFactory.CreateParameter("tempo_estimado", "integer"),
            _parameterFactory.CreateParameter("instrucoes_exercicio", "text/plain"),
            _parameterFactory.CreateParameter("numero_questoes", "integer"),
            _parameterFactory.CreateParameter("link_material_apoio", "URL")
        };

        return Ok(parameters);
    }
}
