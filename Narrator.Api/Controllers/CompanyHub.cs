using System.Collections.Generic;
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
		private IRepository Repository { get; }

		public CompanyHub(ILogger<CompanyHub> logger, IRepository repository)
		{
			Logger = logger;
			Repository = repository;
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
			var item = await Repository.FetchFirst<Encounter>();

			await Clients.Group(groupName).SendAsync("Encounter", item);
		}
	}
}
