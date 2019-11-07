using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Narrator.Models
{
	public class Character
	{
		public Character()
		{
			CharacterEncounters = new List<CharacterEncounter>();
			LootTransactionCharacters = new List<LootTransactionCharacter>();
		}

		public Guid CharacterId { get; set; }
		public Guid CompanyId { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public string Player { get; set; }

		[JsonIgnore]
		public Company Company { get; set; }

		public List<CharacterEncounter> CharacterEncounters { get; set; }
		public List<LootTransactionCharacter> LootTransactionCharacters { get; set; }
	}
}
