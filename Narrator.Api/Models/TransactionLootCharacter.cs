using System;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class TransactionLootCharacter : TransactionLoot
	{
		[Key]
		public Guid CharacterId { get; set; }

		public Character Character { get; set; }
	}
}
