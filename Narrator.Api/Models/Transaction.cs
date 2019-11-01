using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class Transaction
	{
		[Key]
		public Guid TransactionId { get; set; }

		public List<TransactionLoot> TransactionLoots { get; set; }

		public bool IsValid() => TransactionLoots.Sum(s => s.Quantity) == 0;
	}
}
