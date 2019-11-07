using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Narrator.Models
{
	public class Encounter
	{
		public Encounter()
		{
			CharacterEncounters = new List<CharacterEncounter>();
			LootTransactionEncounters = new List<LootTransactionEncounter>();
		}

		public Guid EncounterId { get; set; }
		public Guid CompanyId { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		[JsonIgnore]
		public Company Company { get; set; }

		public List<CharacterEncounter> CharacterEncounters { get; set; }
		public List<LootTransactionEncounter> LootTransactionEncounters { get; set; }
	}
}
