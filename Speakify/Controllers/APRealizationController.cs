using Microsoft.AspNetCore.Mvc;
using Speakify.Models;

[ApiController]
[Route("api/ap-realization")]
public class APRealizationController : ControllerBase
{
    /// <summary>
    /// Realiza o deploy inicial da atividade.
    /// </summary>
    [HttpGet("user_url")]
    public IActionResult DeployActivity(int activityID)
    {
        string activityUrl = $"https://speakify-u5hk.onrender.com?activity={activityID}";
        return Ok(new { url = activityUrl });
    }

    /// <summary>
    /// Regista o acesso do estudante à atividade.
    /// </summary>
    [HttpPost("provide_student_activity_url")]
    public IActionResult StudentAccess([FromBody] StudentAccessRequest requestData)
    {
        return Ok("Exercicio número " + requestData.ActivityID + " vai ser realizado pelo aluno com ID " +
            requestData.InveniraStdID + " no URL: " +
            $"https://speakify-u5hk.onrender.com?activity={requestData.ActivityID}&studentID={requestData.InveniraStdID}");
    }
}
