using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class WindCard : CardBase, IMergeCard{
		public bool CanMerge(CardBase card)
		{
			throw new System.NotImplementedException();
		}

		private void Start() {
			type = CardType.Wind;
		}
		
		protected override void ProcessVillageByCard(Village village) {
			if (village.currentEvent == EventInVillage.Fog) {
				Debug.Log("Fog canceled");
				village.currentEvent = EventInVillage.None;
				VillageController.Singleton.village.currentState = Village.State.Idle;
			}
		}
	}
}