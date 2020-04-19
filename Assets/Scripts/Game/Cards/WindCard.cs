using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class WindCard : CardBase{
		public override bool CanMerge(CardBase card)
		{
			throw new System.NotImplementedException();
		}

		protected override void ProcessVillageByCard(Village village) {
			if (village.currentEvent == InVillageEvent.Fog) {
				Debug.Log("Fog canceled");
				village.currentEvent = InVillageEvent.None;
			}
		}
	}
}