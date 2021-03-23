using System;
using System.Collections.Generic;

namespace Narrator.Models
{
	public class Transaction
	{
		public Transaction()
		{
			LootTransactionCharacters = new List<LootTransactionCharacter>();
			LootTransactionEncounters = new List<LootTransactionEncounter>();
		}

		public Guid TransactionId { get; set; }

		public string Description { get; set; }

		public List<LootTransactionCharacter> LootTransactionCharacters { get; set; }
		public List<LootTransactionEncounter> LootTransactionEncounters { get; set; }
	}
}
