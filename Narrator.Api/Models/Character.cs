using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class Character
	{
		[Key]
		public Guid CharacterId { get; set; }
		public Guid CompanyId { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public string Player { get; set; }

		public Company Company { get; set; }

		public List<CharacterEncounter> CharacterEncounters { get; set; }
		public List<TransactionLootCharacter> TransactionLootCharacters { get; set; }
	}
}
