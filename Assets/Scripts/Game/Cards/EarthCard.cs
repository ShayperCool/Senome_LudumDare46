using System;
using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class EarthCard : CardBase, IMergeCard {
		public bool CanMerge(CardBase card) {
			return false;
		}

		private void Start() {
			type = CardType.Earth;
		}

		protected override void ProcessVillageByCard(Village village) {
			if (village.currentEvent == EventInVillage.Earthquake || village.currentEvent == EventInVillage.Plague) {
				Debug.Log("Earthquake canceled");
				village.currentEvent = EventInVillage.None;
			}
		}
	}
}