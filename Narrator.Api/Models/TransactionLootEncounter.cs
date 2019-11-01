using System;

namespace Narrator.Models
{
	public class TransactionLootEncounter: TransactionLoot
	{
		public Guid EncounterId { get; set; }

		public Encounter Encounter { get; set; }
	}
}
