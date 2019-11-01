using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class Encounter
	{
		[Key]
		public Guid EncounterId { get; set; }
		public Guid CompanyId { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }

		public Company Company { get; set; }

		public List<CharacterEncounter> CharacterEncounters { get; set; }
		public List<TransactionLootEncounter> TransactionLootEncounters { get; set; }
	}
}
