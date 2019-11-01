using System;
using Dapper.Contrib.Extensions;

namespace Narrator.Models
{
	public class CharacterEncounter
	{
		[Key]
		public Guid CharacterId { get; set; }
		[Key]
		public Guid EncounterId { get; set; }

		public int Shares { get; set; }

		public Character Character { get; set; }
		public Encounter Encounter { get; set; }
	}
}
