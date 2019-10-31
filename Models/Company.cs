using System;
using System.Collections.Generic;

namespace Narrator.Models
{
	public class Company
	{
		public Guid CompanyId { get; set; }

		public List<Character> Characters { get; set; }
		public List<Encounter> Encounters { get; set; }
		public List<Loot> Loots { get; set; }
	}
}
