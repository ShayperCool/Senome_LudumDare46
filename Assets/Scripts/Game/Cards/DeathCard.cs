using System;
using System.ComponentModel;
using Game.Models;
using UnityEngine;

namespace Game.Cards {
	public class DeathCard : CardBase {

		public int toKillCount;
		
		protected override void ProcessVillageByCard(Village village) {
			;
			village.villagersCount -= Convert.ToInt32(toKillCount * village.Coefficient);
		}
	}
}