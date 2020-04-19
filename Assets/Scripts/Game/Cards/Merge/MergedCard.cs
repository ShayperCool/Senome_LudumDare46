using System.Collections.Generic;
using Game.Models;
using UnityEngine.UI;

namespace Game.Cards.Merge {
	public class MergedCard : CardBase {
		public List<CardBase> cards = new List<CardBase>();

		protected override void ProcessVillageByCard(Village village) {
			MergedCardsController.ProcessVillage(ToString(), village);
		}

		public override string ToString() {
			string pattern = "";
			foreach (var cardBase in cards) {
				pattern += (char)cardBase.type;
			}
			return pattern;
		}
		
	}
}