using System;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class TransactionLootEncounter
	{
		[Key]
		public Guid LootId { get; set; }
		[Key]
		public Guid TransactionId { get; set; }
		[Key]
		public Guid EncounterId { get; set; }

		public int Quantity { get; set; }

		public Transaction Transaction { get; set; }
		public Loot Loot { get; set; }
		public Encounter Encounter { get; set; }
	}
}
