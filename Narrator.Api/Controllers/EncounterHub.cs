using System;
using System.Collections.Generic;
using System.Linq;
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

		private IRepository<Transaction> Repository { get; }

		public EncounterHub(ILogger<EncounterHub> logger, IHubContext<CompanyHub, ICompanyHub> companyHub, IRepository<Transaction> repository)
		{
			Logger = logger;
			Repository = repository;
			CompanyHub = companyHub;
		}
		public async Task Update(Guid companyId)
		{
			var test = new Transaction
			{
				TransactionId = new Guid(),
				TransactionLootEncounters = new List<LootTransactionEncounter>
				{
					new LootTransactionEncounter
					{
						TransactionId = new Guid(),
						EncounterId = new Guid()
					}
				}
			};

			var result = Repository.Insert(test);

			await CompanyHub.Clients.Group(companyId.ToString()).Sync("I have an update");
		}
	}
}
