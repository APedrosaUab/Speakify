using Microsoft.AspNetCore.Mvc;
using Speakify.Facades;
using Speakify.Interfaces;

[ApiController]
[Route("api/ap-configuration")]
public class APConfigurationController : Controller // Herda de Controller para suportar views
{
    private readonly IConfigurationFacade _configurationFacade;

    public APConfigurationController(IConfigurationFacade configurationFacade)
    {
        _configurationFacade = configurationFacade;
    }

    /// <summary>
    /// Retorna a página de configuração da atividade (HTML).
    /// </summary>
    [HttpGet("config_url")]
    public IActionResult GetConfigurationPage()
    {
        // Retorna a view diretamente (a geração de HTML é feita pela view)
        return View("~/Views/Configuration/ConfigurationPage.cshtml");
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