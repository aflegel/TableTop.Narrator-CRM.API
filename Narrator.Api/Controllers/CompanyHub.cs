using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Narrator.Models;
using Narrator.Services;

namespace Narrator.Controllers
{
	public class CompanyHub : Hub
	{
		private ILogger<CompanyHub> Logger { get; }
		private IEnumerable<IRepository> Repositories { get; }

		public CompanyHub(ILogger<CompanyHub> logger, IEnumerable< IRepository> repositories)
		{
			Logger = logger;
			Repositories = repositories;
		}

		public async Task JoinGroup(string groupName)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

			await Clients.Group(groupName).SendAsync("JoinGroup", $"{Context.ConnectionId} has joined the group {groupName}.");
		}

		public async Task LeaveGroup(string groupName)
		{
			await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

			await Clients.Group(groupName).SendAsync("LeftGroup", $"{Context.ConnectionId} has left the group {groupName}.");
		}

		public async Task GetEncounter(string groupName)
		{
			var item = await Repositories.First(f => f.MatchType<Encounter>()).FetchFirst<Encounter>();

			await Clients.Group(groupName).SendAsync("Encounter", item);
		}
	}
}
