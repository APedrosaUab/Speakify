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
    [HttpGet("config-page")]
    public ActionResult GetConfigurationPage()
    {
        string htmlContent = "<!DOCTYPE html>" +
                             "<html>" +
                             "<head>" +
                             "<meta charset='UTF-8'>" +
                             "<title>Configuracao da Atividade</title>" +
                             "</head>" +
                             "<body>" +
                             "<h1>Configuracao da Atividade</h1>" +
                             "<form>" +
                             "<label>Tipo de Exercicio:</label>" +
                             "<select name='tipo_exercicio'>" +
                             "<option value='gramatica'>Gramatica</option>" +
                             "<option value='vocabulario'>Vocabulario</option>" +
                             "<option value='conversacao'>Conversacao</option>" +
                             "</select><br/>" +
                             "<label>Nivel de Dificuldade:</label>" +
                             "<input type='number' name='nivel_dificuldade' min='1' max='5'/><br/>" +
                             "<label>Objetivo da Atividade:</label>" +
                             "<input type='text' name='objetivo_atividade'/><br/>" +
                             "<label>Tempo Estimado (minutos):</label>" +
                             "<input type='number' name='tempo_estimado'/><br/>" +
                             "<label>Instrucoes:</label>" +
                             "<textarea name='instrucoes_exercicio'></textarea><br/>" +
                             "<label>Numero de Questoes:</label>" +
                             "<input type='number' name='numero_questoes'/><br/>" +
                             "<label>Material de Apoio:</label>" +
                             "<input type='url' name='link_material_apoio'/><br/>" +
                             "<button type='submit'>Salvar</button>" +
                             "</form>" +
                             "</body>" +
                             "</html>";
        return Content(htmlContent, "text/html; charset=utf-8");
    }


    /// <summary>
    /// Retorna os parâmetros configuráveis no formato JSON.
    /// </summary>
    [HttpGet("json-params")]
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
    /// Retorna a lista de analytics disponíveis.
    /// </summary>
    [HttpGet("analytics-list")]
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
    /// Realiza o deploy inicial da atividade.
    /// </summary>
    [HttpGet("deploy-activity")]
    public IActionResult DeployActivity(int activityID)
    {
        string activityUrl = $"https://speakify-u5hk.onrender.com?activity={activityID}";

        return Ok(new { url = activityUrl });
    }

    /// <summary>
    /// Regista o acesso do estudante à atividade.
    /// </summary>
    [HttpPost("student-access")]
    public IActionResult StudentAccess([FromBody]StudentAccessRequest requestData)
    {

        return Ok("Exercicio número " + requestData.ActivityID + " vai ser realizada pelo aluno com ID " + requestData.InveniraStdID);
    }

    /// <summary>
    /// Retorna os dados analíticos da atividade.
    /// </summary>
    [HttpPost("get-analytics")]
    public IActionResult GetActivityAnalytics([FromBody] int inveniraStdID)
    {
        // Dados simulados
        var allAnalytics = StudentAnalyticsData.GetAllAnalytics();

        // Filtrar o resultado com base no ID do estudante
        var studentAnalytics = allAnalytics.Find(analytics => analytics.InveniraStdID == inveniraStdID);

        if (studentAnalytics == null)
        {
            return NotFound(new { message = "Nenhum dado encontrado para o ID fornecido." });
        }

        return Ok(studentAnalytics);
    }
}

