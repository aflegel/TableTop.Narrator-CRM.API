using System;
using System.Collections.Generic;

namespace Narrator.Models
{
	public class Character
	{
		public Guid CharacterId { get; set; }
		public Guid CompanyId { get; set; }

		public Company Company { get; set; }

		public List<CharacterEncounter> CharacterEncounters { get; set; }
		public List<TransactionLootCharacter> TransactionLootCharacters { get; set; }
	}
}
