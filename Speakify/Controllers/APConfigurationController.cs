using Microsoft.AspNetCore.Mvc;
using Speakify.Facades;

[ApiController]
[Route("api/ap-configuration")]
public class APConfigurationController : ControllerBase
{
    private readonly ConfigurationFacade _configurationFacade;

    public APConfigurationController(ConfigurationFacade configurationFacade)
    {
        _configurationFacade = configurationFacade;
    }

    /// <summary>
    /// Retorna a página de configuração da atividade (HTML).
    /// </summary>
    [HttpGet("config_url")]
    public IActionResult GetConfigurationPage()
    {
        var htmlContent = _configurationFacade.GetConfigurationPageHtml();
        return Content(htmlContent, "text/html; charset=utf-8");
    }

    /// <summary>
    /// Retorna os parâmetros configuráveis no formato JSON.
    /// </summary>
    [HttpGet("json_params_url")]
    public IActionResult GetJsonParams()
    {
        var parameters = _configurationFacade.GetConfigurableParameters();
        return Ok(parameters);
    }
}
