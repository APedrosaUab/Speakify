using Microsoft.AspNetCore.Mvc;
using Speakify.Interfaces; // Importar as interfaces
using Speakify.Implementations; // Importar as implementações
using Speakify.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ActivityProviderController : ControllerBase
{
    // Dependência da factory (instanciada diretamente aqui, mas poderia ser injetada via DI)
    private readonly IParameterFactory _parameterFactory;

    public ActivityProviderController()
    {
        // Inicializar a factory para criação de parâmetros
        _parameterFactory = new ConfigurableParameterFactory();
    }

    /// <summary>
    /// Retorna a página de configuração da atividade (HTML).
    /// </summary>
    [HttpGet("config_url")]
    public ActionResult GetConfigurationPage()
    {
        // Método original para retornar a página HTML de configuração (sem alterações)
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
        // Criar os parâmetros configuráveis com a factory
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

        // Retornar os parâmetros no formato JSON
        return Ok(parameters);
    }

    /// <summary>
    /// Realiza o deploy inicial da atividade.
    /// </summary>
    [HttpGet("user_url")]
    public IActionResult DeployActivity(int activityID)
    {
        // Gerar a URL da atividade com base no ID fornecido
        string activityUrl = $"https://speakify-u5hk.onrender.com?activity={activityID}";

        // Retornar a URL no formato JSON
        return Ok(new { url = activityUrl });
    }

    /// <summary>
    /// Retorna os dados analíticos da atividade.
    /// </summary>
    [HttpPost("analytics_url")]
    public IActionResult GetActivityAnalytics([FromBody] int activityID)
    {
        // Obter dados simulados da classe StudentAnalyticsData
        var allAnalytics = StudentAnalyticsData.GetAllAnalytics();

        // Filtrar os dados com base no ID da atividade
        var activityAnalytics = allAnalytics.Find(analytics => analytics.ActivityID == activityID);

        // Se não for encontrado, retornar erro 404
        if (activityAnalytics == null)
        {
            return NotFound(new { message = "Nenhum dado encontrado para o ID da Atividade fornecido." });
        }

        // Retornar os dados analíticos
        return Ok(activityAnalytics);
    }

    /// <summary>
    /// Retorna a lista de analytics disponíveis, usando Factory Method.
    /// </summary>
    [HttpGet("analytics_list_url")]
    public IActionResult GetAnalyticsList()
    {
        var analytics = new
        {
            quantAnalytics = new[]
            {
                _parameterFactory.CreateAnalytics("Tempo total dedicado", "quantitative"),
                _parameterFactory.CreateAnalytics("Número de atividades concluídas", "quantitative"),
                _parameterFactory.CreateAnalytics("Pontuação média", "quantitative"),
                _parameterFactory.CreateAnalytics("Número de tentativas", "quantitative"),
                _parameterFactory.CreateAnalytics("Frequência de acesso", "quantitative")
            },
            qualAnalytics = new[]
            {
                _parameterFactory.CreateAnalytics("Comentários sobre o progresso", "qualitative"),
                _parameterFactory.CreateAnalytics("Sugestões para melhoria", "qualitative"),
                _parameterFactory.CreateAnalytics("Feedback qualitativo do aluno", "qualitative"),
            }
        };

        return Ok(analytics);
    }

    /// <summary>
    /// Regista o acesso do estudante à atividade.
    /// </summary>
    [HttpPost("provide_student_activity_url")]
    public IActionResult StudentAccess([FromBody] StudentAccessRequest requestData)
    {
        // Simular o registo do estudante no sistema e retornar a URL da atividade
        return Ok("Exercicio número " + requestData.ActivityID + " vai ser realizado pelo aluno com ID " +
            requestData.InveniraStdID + " no URL: " +
            $"https://speakify-u5hk.onrender.com?activity={requestData.ActivityID}&studentID={requestData.InveniraStdID}");
    }
}
