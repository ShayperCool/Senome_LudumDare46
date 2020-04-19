using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class SunCard : CardBase {
		public override bool CanMerge(CardBase card)
		{
			throw new System.NotImplementedException();
		}

		protected override void ProcessVillageByCard(Village village) {
			if (village.currentEvent == InVillageEvent.Flood) {
				Debug.Log("Flood canceled");
				village.currentEvent = InVillageEvent.None;
			}
		}
	}
}