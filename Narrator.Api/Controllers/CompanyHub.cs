using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Narrator.Services;

namespace Narrator.Controllers
{
	public interface ICompanyHub
	{
		public Task Sync(object payload);
		public Task Error(string message);
	}

	public class CompanyHub : Hub<ICompanyHub>
	{
		private ILogger<CompanyHub> Logger { get; }
		private CompanyRepository Repository { get; }

		public CompanyHub(ILogger<CompanyHub> logger, CompanyRepository repository)
		{
			Logger = logger;
			Repository = repository;
		}


		public async Task JoinGroup(string groupName) => await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

		public async Task LeaveGroup(string groupName) => await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

		public async Task GetTransactions()
		{
			var test = await Repository.Select();

			await Clients.Clients(Context.ConnectionId).Sync(test);
		}
	}
}
