using System;
using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class SunCard : CardBase, IMergeCard {
		public bool CanMerge(CardBase card)
		{
			throw new System.NotImplementedException();
		}

		private void Start() {
			type = CardType.Sun;
		}

		protected override void ProcessVillageByCard(Village village) {
			if (village.currentEvent == EventInVillage.Flood) {
				Debug.Log("Flood canceled");
				village.currentEvent = EventInVillage.None;
			}
		}
	}
}