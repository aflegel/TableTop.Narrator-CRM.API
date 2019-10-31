using System;
using System.Collections.Generic;

namespace Narrator.Models
{
	public class Encounter
	{
		public Guid EncounterId { get; set; }
		public Guid CompanyId { get; set; }

		public Company Company { get; set; }

		public List<CharacterEncounter> CharacterEncounters { get; set; }
		public List<TransactionLootEncounter> TransactionLootEncounters { get; set; }
	}
}
