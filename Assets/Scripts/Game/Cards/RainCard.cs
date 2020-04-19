using System;
using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class RainCard : CardBase {
		public override bool CanMerge(CardBase card)
		{
			throw new NotImplementedException();
		}

		protected override void ProcessVillageByCard(Village village) {
			if (village.currentEvent == InVillageEvent.Fire) {
				Debug.Log("Fire canceled");
				village.currentEvent = InVillageEvent.None;
			}
		}
	}
}