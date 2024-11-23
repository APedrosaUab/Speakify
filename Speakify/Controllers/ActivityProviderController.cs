using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ActivityProviderController : ControllerBase
{
    /// <summary>
    /// Retorna a p�gina de configura��o da atividade (HTML).
    /// </summary>
    [HttpGet("config-page")]
    public ContentResult GetConfigurationPage()
    {
        string htmlContent = "<html><body>" +
                             "<h1>Configura��o da Atividade</h1>" +
                             "<form>" +
                             "<label>Tipo de Exerc�cio:</label>" +
                             "<select name='tipo_exercicio'>" +
                             "<option value='gram�tica'>Gram�tica</option>" +
                             "<option value='vocabul�rio'>Vocabul�rio</option>" +
                             "<option value='conversa��o'>Conversa��o</option>" +
                             "</select><br/>" +
                             "<label>N�vel de Dificuldade:</label>" +
                             "<input type='number' name='nivel_dificuldade' min='1' max='5'/><br/>" +
                             "<label>Objetivo da Atividade:</label>" +
                             "<input type='text' name='objetivo_atividade'/><br/>" +
                             "<label>Tempo Estimado (minutos):</label>" +
                             "<input type='number' name='tempo_estimado'/><br/>" +
                             "<label>Instru��es:</label>" +
                             "<textarea name='instrucoes_exercicio'></textarea><br/>" +
                             "<label>N�mero de Quest�es:</label>" +
                             "<input type='number' name='numero_questoes'/><br/>" +
                             "<label>Material de Apoio:</label>" +
                             "<input type='url' name='link_material_apoio'/><br/>" +
                             "<button type='submit'>Salvar</button>" +
                             "</form>" +
                             "</body></html>";
        return Content(htmlContent, "text/html");
    }

    /// <summary>
    /// Retorna os par�metros configur�veis no formato JSON.
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
    /// Retorna a lista de analytics dispon�veis.
    /// </summary>
    [HttpGet("analytics-list")]
    public IActionResult GetAnalyticsList()
    {
        var analytics = new
        {
            quantAnalytics = new[]
            {
                new { name = "Tempo total dedicado", type = "float" },
                new { name = "N�mero de atividades conclu�das", type = "integer" }
            },
            qualAnalytics = new[]
            {
                new { name = "Resumo do progresso", type = "text/plain" },
                new { name = "Mapa de calor", type = "URL" }
            }
        };

        return Ok(analytics);
    }

    /// <summary>
    /// Realiza o deploy inicial da atividade.
    /// </summary>
    [HttpPost("deploy-activity")]
    public IActionResult DeployActivity([FromBody] dynamic requestData)
    {
        string activityID = requestData.activityID;
        string activityUrl = $"https://yourAPProvider.com/activity/{activityID}";

        // Simula qualquer prepara��o no servidor (e.g., inicializa��o de registros)
        return Ok(new { url = activityUrl });
    }

    /// <summary>
    /// Registra o acesso do estudante � atividade.
    /// </summary>
    [HttpPost("student-access")]
    public IActionResult StudentAccess([FromBody] dynamic requestData)
    {
        string activityUrl = $"https://yourAPProvider.com/activity/{requestData.activityID}?studentId={requestData.InvenRAstdID}";

        return Ok(new { url = activityUrl });
    }

    /// <summary>
    /// Retorna os dados anal�ticos da atividade.
    /// </summary>
    [HttpPost("analytics")]
    public IActionResult GetActivityAnalytics([FromBody] dynamic requestData)
    {
        var analytics = new List<StudentAnalytics>
    {
        new StudentAnalytics
        {
            InveniraStdID = "1001",
            QuantAnalytics = new List<QuantitativeAnalytic>
            {
                new QuantitativeAnalytic { Name = "Acedeu � atividade", Value = true },
                new QuantitativeAnalytic { Name = "Download documento 1", Value = true },
                new QuantitativeAnalytic { Name = "Evolu��o pela atividade (%)", Value = 33.3 }
            },
            QualAnalytics = new List<QualitativeAnalytic>
            {
                new QualitativeAnalytic { Name = "Student activity profile", Value = "https://ActivityProvider/?APAnID=11111111" },
                new QualitativeAnalytic { Name = "Activity Heat Map", Value = "https://ActivityProvider/?APAnID=21111111" }
            }
        },
        new StudentAnalytics
        {
            InveniraStdID = "1002",
            QuantAnalytics = new List<QuantitativeAnalytic>
            {
                new QuantitativeAnalytic { Name = "Acedeu � atividade", Value = true },
                new QuantitativeAnalytic { Name = "Download documento 1", Value = false },
                new QuantitativeAnalytic { Name = "Evolu��o pela atividade (%)", Value = 10.0 }
            },
            QualAnalytics = new List<QualitativeAnalytic>
            {
                new QualitativeAnalytic { Name = "Student activity profile", Value = "https://ActivityProvider/?APAnID=11111112" },
                new QualitativeAnalytic { Name = "Activity Heat Map", Value = "https://ActivityProvider/?APAnID=21111112" }
            }
        }
    };

        return Ok(analytics);
    }


    /// <summary>
    /// Simula uma chamada ao ChatGPT para gera��o de perguntas.
    /// </summary>
    private async Task<string> SimulateChatGPTRequest(dynamic config)
    {
        await Task.Delay(500); // Simula��o de processamento
        return "Perguntas geradas com base na configura��o fornecida.";
    }
}

public class QuantitativeAnalytic
{
    public string Name { get; set; }
    public object Value { get; set; } // Aceita diferentes tipos de valores (bool, float, etc.)
}

public class QualitativeAnalytic
{
    public string Name { get; set; }
    public string Value { get; set; }
}

public class StudentAnalytics
{
    public string InveniraStdID { get; set; }
    public List<QuantitativeAnalytic> QuantAnalytics { get; set; }
    public List<QualitativeAnalytic> QualAnalytics { get; set; }
}
