using System;
using System.ComponentModel;
using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class DeathCard : CardBase, IMergeCard {

		private static readonly int _toKillCount = 50;

		public bool CanMerge(CardBase card) {
			return card.type == CardType.Death;
		}

		private void Start() {
			type = CardType.Death;
		}

		protected override void ProcessVillageByCard(Village village) {
			village.villagersCount -= _toKillCount;
		}
	}
}