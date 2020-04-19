using System;
using System.ComponentModel;
using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class DeathCard : CardBase {

		private static readonly int _toKillCount = 50;

		public override bool CanMerge(CardBase card)
		{
			throw new NotImplementedException();
		}

		protected override void ProcessVillageByCard(Village village) {
			village.villagersCount -= _toKillCount;
		}
	}
}