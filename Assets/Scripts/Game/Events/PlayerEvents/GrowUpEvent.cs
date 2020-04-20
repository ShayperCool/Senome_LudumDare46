using System;
using Game.Models;

namespace Game.Events.PlayerEvents {
	public class GrowUpEvent: IEventInVillage {
		private static readonly int _growUpCount = 3;
		
		public void ProcessVillage(Village village) {
			village.villagersCount += Convert.ToInt32(_growUpCount * village.Coefficient);
		}
	}
}