using System;
using System.Text.Json.Serialization;

namespace Narrator.Models
{
	public class CharacterEncounter
	{
		public Guid CharacterId { get; set; }
		public Guid EncounterId { get; set; }

		public int Shares { get; set; }

		[JsonIgnore]
		public Character Character { get; set; }
		[JsonIgnore]
		public Encounter Encounter { get; set; }
	}
}
