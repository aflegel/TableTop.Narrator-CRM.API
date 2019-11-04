﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Narrator.Models;
using Narrator.Services;

namespace Narrator.Controllers
{
	public interface IComapnyHub
	{
		public Task Sync(object payload);
	}

	public class CompanyHub : Hub<IComapnyHub>
	{
		private ILogger<CompanyHub> Logger { get; }
		private IRepository<Transaction> Repository { get; }

		public CompanyHub(ILogger<CompanyHub> logger, IRepository<Transaction> repository)
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
