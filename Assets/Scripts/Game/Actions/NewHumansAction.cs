using Game.Models;

namespace Game.Actions {
	public class NewHumansAction : IEventInVillage {

		private int _humansToAdd = 50;
		
		public void ProcessVillage(Village village) {
			village.villagersCount += _humansToAdd;
		}
	}
}