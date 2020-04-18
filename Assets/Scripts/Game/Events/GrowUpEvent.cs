using System;
using Game.Models;

namespace Game.Events {
	public class GrowUpEvent: IEventInVillage {
		private int _growUpCount = 3;
		
		public void ProcessVillage(Village village) {
			village.villagersCount += Convert.ToInt32(_growUpCount * village.Coefficient);
		}
	}
}