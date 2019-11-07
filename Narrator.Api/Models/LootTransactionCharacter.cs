using System;
using System.Text.Json.Serialization;

namespace Narrator.Models
{
	public class LootTransactionCharacter
	{
		public Guid LootId { get; set; }
		public Guid TransactionId { get; set; }
		public Guid CharacterId { get; set; }

		public int Quantity { get; set; }

		[JsonIgnore]
		public Transaction Transaction { get; set; }
		[JsonIgnore]
		public Loot Loot { get; set; }
		[JsonIgnore]
		public Character Character { get; set; }
	}
}
