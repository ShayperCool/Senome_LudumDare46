using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class EarthCard : CardBase {
		public override bool CanMerge(CardBase card)
		{
			throw new System.NotImplementedException();
		}

		protected override void ProcessVillageByCard(Village village) {
			if (village.currentEvent == InVillageEvent.Earthquake || village.currentEvent == InVillageEvent.Plague) {
				Debug.Log("Earthquake canceled");
				village.currentEvent = InVillageEvent.None;
			}
		}
	}
}