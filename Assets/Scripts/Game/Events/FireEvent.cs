using Game.Models;
using UnityEngine;

namespace Game.Events {
	public class FireEvent : IEventInVillage {
		public void ProcessVillage(Village village) {
			Debug.Log("Fire!!");
			village.currentState = Village.State.Danger;
			village.currentEvent = InVillageEvent.Fire;
		}
	}
}