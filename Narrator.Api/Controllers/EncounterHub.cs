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
		private IEnumerable<IRepository> Repositories { get; }

		private IHubContext<CompanyHub, ICompanyHub> CompanyHub { get; }

		public EncounterHub(ILogger<EncounterHub> logger, IHubContext<CompanyHub, ICompanyHub> companyHub, IEnumerable<IRepository> repositories)
		{
			Logger = logger;
			Repositories = repositories;
			CompanyHub = companyHub;
		}
		public async Task Update(Guid companyId)
		{


			await CompanyHub.Clients.Group(companyId.ToString()).Update("I have an update");
		}
	}
}
