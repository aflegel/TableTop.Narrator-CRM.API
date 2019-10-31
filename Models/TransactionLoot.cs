using System;

namespace Narrator.Models
{
	public class TransactionLoot
	{
		public Guid TransactionId { get; set; }
		public Guid LootId { get; set; }

		public int Quantity { get; set; }

		public Transaction Transaction { get; set; }
		public Loot Loot { get; set; }
	}
}
