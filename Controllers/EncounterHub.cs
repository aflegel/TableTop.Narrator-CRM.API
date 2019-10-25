using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Narrator.Controllers
{
	public class EncounterHub : Hub
	{
		ILogger<EncounterHub> Logger { get; }

		public EncounterHub(ILogger<EncounterHub> logger)
		{
			Logger = logger;
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

		public Task IncrementCounter(string groupName)
		{
			return Clients.GroupExcept(groupName, new List<string> { Context.ConnectionId }).SendAsync("IncrementCounter");
		}

		public Task DecrementCounter(string groupName)
		{
			return Clients.GroupExcept(groupName, new List<string> { Context.ConnectionId }).SendAsync("DecrementCounter");
		}
	}
}
