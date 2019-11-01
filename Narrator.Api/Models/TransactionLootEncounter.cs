using System;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class TransactionLootEncounter: TransactionLoot
	{
		[Key]
		public Guid EncounterId { get; set; }

		public Encounter Encounter { get; set; }
	}
}
