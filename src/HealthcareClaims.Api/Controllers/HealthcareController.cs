using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareClaims.Api.Controllers
{
    [Route("api/healthcontroller")]
    [ApiController]
    public class HealthcareController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                status = "Healthy",
                message="HealthcareClaims api is running"
            });
        }
    }
}
