using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public abstract class CardBase : MonoBehaviour ,IEventInVillage {

		public CardParameters parameters;
		
		public void ProcessVillage(Village village) {
			ProcessVillageByCard(village);
		}

		protected abstract void ProcessVillageByCard(Village village);

	}
}