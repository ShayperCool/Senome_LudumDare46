using Game.Models;

namespace Game.Events.AiEvents {
	public class DeathEvent : IEventInVillage {

		private static readonly int _toKillCount = 30;
		
		public void ProcessVillage(Village village) {
			village.villagersCount -= _toKillCount;
		}
	}
}