using Microsoft.AspNetCore.Mvc;
using Speakify.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ActivityProviderController : ControllerBase
{
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
    /// Retorna os parâmetros configuráveis no formato JSON.
    /// </summary>
    [HttpGet("json_params_url")]
    public IActionResult GetJsonParams()
    {
        var parameters = new List<object>
    {
        new { name = "tipo_exercicio", type = "text/plain" },
        new { name = "nivel_dificuldade", type = "integer" },
        new { name = "objetivo_atividade", type = "text/plain" },
        new { name = "tempo_estimado", type = "integer" },
        new { name = "instrucoes_exercicio", type = "text/plain" },
        new { name = "numero_questoes", type = "integer" },
        new { name = "link_material_apoio", type = "URL" }
    };

        return Ok(parameters);
    }

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
    /// Retorna os dados analíticos da atividade.
    /// </summary>
    [HttpPost("analytics_url")]
    public IActionResult GetActivityAnalytics([FromBody] int activityID)
    {
        // Dados simulados
        var allAnalytics = StudentAnalyticsData.GetAllAnalytics();

        // Filtrar o resultado com base no ID da Activity
        var activityAnalytics = allAnalytics.Find(analytics => analytics.ActivityID == activityID);

        if (activityAnalytics == null)
        {
            return NotFound(new { message = "Nenhum dado encontrado para o ID da Atividade fornecido." });
        }

        return Ok(activityAnalytics);
    }

    /// <summary>
    /// Retorna a lista de analytics disponíveis.
    /// </summary>
    [HttpGet("analytics_list_url")]
    public IActionResult GetAnalyticsList()
    {
        var analytics = new
        {
            quantAnalytics = new[]
            {
                new { name = "Tempo total dedicado", type = "float" },
                new { name = "Número de atividades concluídas", type = "integer" },
                new { name = "Pontuação média", type = "float" },
                new { name = "Número de tentativas", type = "integer" },
                new { name = "Frequência de acesso", type = "integer" }
            },
            qualAnalytics = new[]
            {
                new { name = "Comentários sobre o progresso", type = "text/plain" },
                new { name = "Sugestões para melhoria", type = "text/plain" },
                new { name = "Feedback qualitativo do aluno", type = "text/plain" },
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
        // Tratamento da lógica toda da instanciação do exercício e da acção do estudante na resolução
        return Ok("Exercicio número " + requestData.ActivityID + " vai ser realizada pelo aluno com ID " + requestData.InveniraStdID + 
            " no URL: " + $"https://speakify-u5hk.onrender.com?activity={requestData.ActivityID}&studentID={requestData.InveniraStdID}");
    }

   
}

