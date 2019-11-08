using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Narrator.Models;

namespace Narrator.Services
{
	public class CompanyRepository : DbContext
	{
		public CompanyRepository(DbContextOptions<CompanyRepository> options) : base(options) { }

		public DbSet<Company> Companies { get; set; }
		public DbSet<Character> Characters { get; set; }
		public DbSet<Encounter> Encounters { get; set; }
		public DbSet<CharacterEncounter> CharacterEncounters { get; set; }

		public DbSet<Loot> Loots { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<LootTransactionCharacter> LootTransactionCharacters { get; set; }
		public DbSet<LootTransactionEncounter> LootTransactionEncounters { get; set; }

		public ObjectResult<int> GetRemainingLoot(Guid encounterId, Guid lootId) =>
			((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int>("GetRemainingLoot",
				new ObjectParameter("encounterId", encounterId),
				new ObjectParameter("lootId", lootId));

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CharacterEncounter>().HasKey(composite => new { composite.CharacterId, composite.EncounterId });
			modelBuilder.Entity<LootTransactionCharacter>().HasKey(composite => new { composite.LootId, composite.TransactionId, composite.CharacterId });
			modelBuilder.Entity<LootTransactionEncounter>().HasKey(composite => new { composite.LootId, composite.TransactionId, composite.EncounterId });

			modelBuilder.Entity<Character>()
				.HasOne(e => e.Company)
				.WithMany(c => c.Characters);

			modelBuilder.Entity<Encounter>()
				.HasOne(e => e.Company)
				.WithMany(c => c.Encounters);

			modelBuilder.Entity<Loot>()
				.HasOne(e => e.Company)
				.WithMany(c => c.Loots);

			modelBuilder.Entity<CharacterEncounter>()
				.HasOne(e => e.Character)
				.WithMany(c => c.CharacterEncounters);

			modelBuilder.Entity<CharacterEncounter>()
				.HasOne(e => e.Encounter)
				.WithMany(c => c.CharacterEncounters);

			modelBuilder.Entity<LootTransactionCharacter>()
				.HasOne(e => e.Loot)
				.WithMany(c => c.LootTransactionCharacters);

			modelBuilder.Entity<LootTransactionCharacter>()
				.HasOne(e => e.Transaction)
				.WithMany(c => c.LootTransactionCharacters);

			modelBuilder.Entity<LootTransactionCharacter>()
				.HasOne(e => e.Character)
				.WithMany(c => c.LootTransactionCharacters);

			modelBuilder.Entity<LootTransactionEncounter>()
				.HasOne(e => e.Loot)
				.WithMany(c => c.LootTransactionEncounters);

			modelBuilder.Entity<LootTransactionEncounter>()
				.HasOne(e => e.Transaction)
				.WithMany(c => c.LootTransactionEncounters);

			modelBuilder.Entity<LootTransactionEncounter>()
				.HasOne(e => e.Encounter)
				.WithMany(c => c.LootTransactionEncounters);


			/*modelBuilder.Model.GetEntityTypes()
				.SelectMany(t => t.GetProperties())
				.Where(p => p.ClrType == typeof(decimal))
				.ToList().ForEach(property => property.Relational().ColumnType = "decimal(24, 0)");// 100,000,000,000,000,000,000*/
		}
	}
}
