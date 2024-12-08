using Microsoft.AspNetCore.Mvc;
using Speakify.Implementations;
using Speakify.Interfaces;
using Speakify.Models;

[ApiController]
[Route("api/ap-analytics")]
public class APAnalyticsController : ControllerBase
{
    private readonly IParameterFactory _parameterFactory;

    public APAnalyticsController()
    {
        _parameterFactory = new ConfigurableParameterFactory();
    }

    /// <summary>
    /// Retorna os dados analíticos da atividade.
    /// </summary>
    [HttpPost("analytics_url")]
    public IActionResult GetActivityAnalytics([FromBody] int activityID)
    {
        var allAnalytics = StudentAnalyticsData.GetAllAnalytics();
        var activityAnalytics = allAnalytics.Find(analytics => analytics.ActivityID == activityID);

        if (activityAnalytics == null)
        {
            return NotFound(new { message = "Nenhum dado encontrado para o ID da Atividade fornecido." });
        }

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
}
