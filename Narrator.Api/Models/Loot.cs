using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class Loot
	{
		public Loot()
		{
			TransactionLootCharacters = new List<LootTransactionCharacter>();
			TransactionLootEncounters = new List<TransactionLootEncounter>();
		}

		[Key]
		public Guid LootId { get; set; }
		public Guid CompanyId { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Value { get; set; }

		public Company Company { get; set; }

		public List<LootTransactionCharacter> TransactionLootCharacters { get; set; }
		public List<TransactionLootEncounter> TransactionLootEncounters { get; set; }
	}
}
