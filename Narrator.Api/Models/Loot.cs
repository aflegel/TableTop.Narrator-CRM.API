using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Narrator.Models
{
	public class Loot
	{
		public Loot()
		{
			LootTransactionCharacters = new List<LootTransactionCharacter>();
			LootTransactionEncounters = new List<LootTransactionEncounter>();
		}

		public Guid LootId { get; set; }
		public Guid CompanyId { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Value { get; set; }

		public Company Company { get; set; }

		public List<LootTransactionCharacter> LootTransactionCharacters { get; set; }
		public List<LootTransactionEncounter> LootTransactionEncounters { get; set; }
	}
}
