using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class Transaction
	{
		public Transaction()
		{
			TransactionLootCharacters = new List<LootTransactionCharacter>();
			TransactionLootEncounters = new List<TransactionLootEncounter>();
		}

		[Key]
		public Guid TransactionId { get; set; }

		public string Description { get; set; }

		public List<LootTransactionCharacter> TransactionLootCharacters { get; set; }
		public List<TransactionLootEncounter> TransactionLootEncounters { get; set; }

		public bool IsValid() => TransactionLootEncounters.Sum(s => s.Quantity) == 0;
	}
}
