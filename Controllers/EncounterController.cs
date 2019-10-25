using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Narrator.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EncounterController : ControllerBase
    {
		private ILogger<EncounterController> Logger { get; }

		public EncounterController(ILogger<EncounterController> logger)
		{
			Logger = logger;
		}

		[HttpGet()]
		public ActionResult Index() => Ok();
	}
}
