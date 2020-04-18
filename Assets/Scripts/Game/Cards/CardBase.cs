using Game.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Cards {
	public abstract class CardBase : MonoBehaviour ,IEventInVillage {
		public CardParameters parameters;
		
		public Image foreground;
		public Image background;
		public Text description;
		public Text title;

		public void ProcessVillage(Village village) {
			ProcessVillageByCard(village);
		}

		protected abstract void ProcessVillageByCard(Village village);

	}
}