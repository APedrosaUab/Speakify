using Microsoft.AspNetCore.Mvc;
using Speakify.Facades;
using Speakify.Implementations.Observers;

namespace Speakify.Controllers
{
    [ApiController]
    [Route("api/ap-realization")]
    public class APRealizationController : ControllerBase
    {
        private readonly RealizationFacade _realizationFacade;

        public APRealizationController(
            RealizationFacade realizationFacade,
            ActivityLoggingObserver loggingObserver)
        {
            _realizationFacade = realizationFacade;

            // Regista os observers
            _realizationFacade.Attach(loggingObserver);
        }

        [HttpPost("provide_student_activity_url")]
        public IActionResult StudentAccess([FromBody] Models.StudentAccessRequest requestData)
        {
            var url = _realizationFacade.RegisterStudentAccess(requestData.ActivityID, requestData.InveniraStdID);
            return Ok(new { message = $"Acesso registado: {url}" });
        }

        [HttpGet("user_url")]
        public IActionResult DeployActivity(int activityID)
        {
            var url = _realizationFacade.GenerateActivityUrl(activityID);
            return Ok(new { url });
        }
    }
}