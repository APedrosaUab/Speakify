using Microsoft.AspNetCore.Mvc;
using Speakify.Facades;

[ApiController]
[Route("api/ap-analytics")]
public class APAnalyticsController : ControllerBase
{
    private readonly AnalyticsFacade _analyticsFacade;

    public APAnalyticsController(AnalyticsFacade analyticsFacade)
    {
        _analyticsFacade = analyticsFacade;
    }

    /// <summary>
    /// Retorna os dados analíticos de uma atividade específica.
    /// </summary>
    [HttpPost("analytics_url")]
    public IActionResult GetActivityAnalytics([FromBody] int? activityID)
    {
        var analytics = _analyticsFacade.GetActivityAnalytics(activityID);

        if (analytics == null || !analytics.Any())
        {
            if (activityID != null)
            {
                return NotFound(new { message = "Nenhum dado encontrado para o ID da Atividade fornecido." });
            }
            else
            {
                return NotFound(new { message = "Nenhum dado encontrado." });
            }

        }

        return Ok(analytics);
    }

    /// <summary>
    /// Retorna a lista de analytics disponíveis.
    /// </summary>
    [HttpGet("analytics_list_url")]
    public IActionResult GetAnalyticsList()
    {
        var analyticsList = _analyticsFacade.GetAnalyticsList();
        return Ok(analyticsList);
    }
}
