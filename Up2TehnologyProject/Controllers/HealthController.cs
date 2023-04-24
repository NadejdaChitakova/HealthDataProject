using Microsoft.AspNetCore.Mvc;
using Up2TehnologyProject.IServices;

namespace Up2TehnologyProject.Controllers
{
    public class HealthController : Controller
    {
        private readonly IHealthService _healthService;
        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        [HttpGet]
        [Route("/Health")]
        public IActionResult GetJson()
        {
            return Ok(_healthService.GetHealthJsonData());
        }

        [HttpGet]
        [Route("/HealthXml")]
        public IActionResult GetXml()
        {
            return Ok(_healthService.GetHealthXmlData());
        }
    }
}
