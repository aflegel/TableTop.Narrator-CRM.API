using System;
using System.Text.Json.Serialization;

namespace Narrator.Models
{
	public class LootTransactionEncounter
	{
		public Guid LootId { get; set; }
		public Guid TransactionId { get; set; }
		public Guid EncounterId { get; set; }

		public int Quantity { get; set; }

		[JsonIgnore]
		public Transaction Transaction { get; set; }
		[JsonIgnore]
		public Loot Loot { get; set; }
		[JsonIgnore]
		public Encounter Encounter { get; set; }
	}
}
