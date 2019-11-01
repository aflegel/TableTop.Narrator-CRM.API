using System;

namespace Narrator.Models
{
	public class CharacterEncounter
	{
		public Guid CharacterId { get; set; }
		public Guid EncounterId { get; set; }

		public int Shares { get; set; }

		public Character Character { get; set; }
		public Encounter Encounter { get; set; }
	}
}
