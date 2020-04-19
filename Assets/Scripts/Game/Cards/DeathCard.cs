using System;
using System.ComponentModel;
using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class DeathCard : CardBase {

		private static readonly int _toKillCount = 50;
		
		protected override void ProcessVillageByCard(Village village) {
			village.villagersCount -= _toKillCount;
		}
	}
}