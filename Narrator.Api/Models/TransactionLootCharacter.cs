using System;

namespace Narrator.Models
{
	public class TransactionLootCharacter : TransactionLoot
	{
		public Guid CharacterId { get; set; }

		public Character Character { get; set; }
	}
}
