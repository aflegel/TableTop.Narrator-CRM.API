﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Narrator.Controllers;
using Narrator.Models;
using Narrator.Services;

namespace Narrator
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();
			services.AddSignalR();
			services.AddSingleton<IRepository<Encounter>, EncounterRepository>();
			services.AddSingleton<IRepository<Character>, CharacterRepository>();
			services.AddSingleton<IRepository<Transaction>, TransactionRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Until the app is HTTPS ready redirection breaks SignalR
			//app.UseHttpsRedirection();

			app.UseCors(cors => cors.WithOrigins("http://localhost:3000")
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials());

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<EncounterHub>("/Encounter/Sync");
				endpoints.MapHub<CompanyHub>("/Company/Sync");
			});
		}
	}
}
