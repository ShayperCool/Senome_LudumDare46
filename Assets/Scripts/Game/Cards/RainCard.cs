using System;
using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class RainCard : CardBase, IMergeCard {
		public bool CanMerge(CardBase card)
		{
			throw new NotImplementedException();
		}

		private void Start() {
			type = CardType.Rain;
		}
		
		protected override void ProcessVillageByCard(Village village) {
			if (village.currentEvent == EventInVillage.Fire) {
				Debug.Log("Fire canceled");
				village.currentEvent = EventInVillage.None;
			}
		}
		
	}
}