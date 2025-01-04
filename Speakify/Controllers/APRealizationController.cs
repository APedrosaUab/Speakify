using Microsoft.AspNetCore.Mvc;
using Speakify.Facades;
using Speakify.Models;

[ApiController]
[Route("api/ap-realization")]
public class APRealizationController : ControllerBase
{
    private readonly RealizationFacade _realizationFacade;

    public APRealizationController(RealizationFacade realizationFacade)
    {
        _realizationFacade = realizationFacade;
    }

    /// <summary>
    /// Realiza o deploy inicial da atividade.
    /// </summary>
    [HttpGet("user_url")]
    public IActionResult DeployActivity(int activityID)
    {
        var url = _realizationFacade.GenerateActivityUrl(activityID);
        return Ok(new { url });
    }

    /// <summary>
    /// Regista o acesso do estudante à atividade.
    /// </summary>
    [HttpPost("provide_student_activity_url")]
    public IActionResult StudentAccess([FromBody] StudentAccessRequest requestData)
    {
        var url = _realizationFacade.RegisterStudentAccess(requestData.ActivityID, requestData.InveniraStdID);
        return Ok(new { message = $"Acesso registado: {url}" });
    }
}
