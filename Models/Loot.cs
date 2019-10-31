using System;
using System.Collections.Generic;

namespace Narrator.Models
{
	public class Loot
	{
		public Guid LootId { get; set; }
		public Guid CompanyId { get; set; }

		public Company Company { get; set; }

		public List<TransactionLoot> TransactionLoots { get; set; }
	}
}
