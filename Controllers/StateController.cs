using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Narrator.Controllers
{
	public class StateController : Hub
    {
		ILogger<StateController> Logger { get; }

		public StateController(ILogger<StateController> logger)
		{
			Logger = logger;
		}

		public Task IncrementCounter()
		{
			var connectionIDToIgnore = new List<string>
			{
				Context.ConnectionId
			};
			return Clients.AllExcept(connectionIDToIgnore).SendAsync("IncrementCounter");
		}

		public Task DecrementCounter()
		{
			var connectionIDToIgnore = new List<string>
			{
				Context.ConnectionId
			};
			return Clients.AllExcept(connectionIDToIgnore).SendAsync("DecrementCounter");
		}
	}
}
