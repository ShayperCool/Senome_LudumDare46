using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class EarthCard : CardBase {
		protected override void ProcessVillageByCard(Village village) {
			if (village.currentEvent == InVillageEvent.Earthquake || village.currentEvent == InVillageEvent.Plague) {
				Debug.Log("Earthquake canceled");
				village.currentEvent = InVillageEvent.None;
			}
		}
	}
}