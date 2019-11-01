using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class Company
	{
		[Key]
		public Guid CompanyId { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		public List<Character> Characters { get; set; }
		public List<Encounter> Encounters { get; set; }
		public List<Loot> Loots { get; set; }
	}
}
