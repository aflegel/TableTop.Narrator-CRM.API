using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Narrator.Models;
using Narrator.Services;

namespace Narrator.Controllers
{
	public class EncounterHub : Hub
	{
		private ILogger<EncounterHub> Logger { get; }
		private IHubContext<CompanyHub, ICompanyHub> CompanyHub { get; }
		private CompanyRepository Repository { get; }
		private Timer Interval { get; }
		private ClockService ClockService { get; }

		public EncounterHub(ILogger<EncounterHub> logger, IHubContext<CompanyHub, ICompanyHub> companyHub, CompanyRepository repository, ClockService clockService)
		{
			Logger = logger;
			Repository = repository;
			CompanyHub = companyHub;
			ClockService = clockService;
			// Interval = new Timer(Loop, null, 0, 1000);
		}

		private void Loop(object state)
		{
			Logger.LogInformation($"static tick {DateTime.Now:HH:mm:ss}");

			LoopAsync();
			//Control.BeginInvoke(LoopAsync());
		}


		private void LoopAsync()
		{
			var time = ClockService.GetTime();

			CompanyHub.Clients.All.Sync(time);

			Logger.LogInformation("emit tick");
		}

		public async Task Join(string groupName) => await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
		public async Task Leave(string groupName) => await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

		public async Task Increment(string companyId, int number) => await Clients.Group(companyId).SendAsync("Increment", number);
		public async Task Decrement(string companyId, int number) => await Clients.Group(companyId).SendAsync("Decrement", number);

		public async Task Get(Guid companyId)
		{
			var result = await Repository.Select();

			await CompanyHub.Clients.Group(companyId.ToString()).Sync(result);
		}

		public async Task Update(Guid companyId)
		{
			var test = new Transaction
			{
				TransactionId = Guid.NewGuid(),
				Description = "Sample Insert",
				LootTransactionEncounters = new List<LootTransactionEncounter>
				{
					new LootTransactionEncounter
					{
						LootId = Guid.Parse("D422CC1B-7B1A-484A-AC13-B1DD2B4C1E1E"), //Guid.NewGuid(),
						EncounterId = Guid.Parse("374665DC-9076-4558-B106-E0A703D1F384"), //Guid.NewGuid()
						Quantity = -1
					}
				}
			};

			var result = Repository.Insert(test);

			await CompanyHub.Clients.Group(companyId.ToString()).Sync(result);
		}
	}
}
