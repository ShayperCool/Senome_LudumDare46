using Game.Models;
using UnityEngine;

namespace Game.Events.AiEvents {
	public class FloodEvent : IEventInVillage {
		public void ProcessVillage(Village village) {
			Debug.Log("Flood!!");
			village.currentState = Village.State.Danger;
			village.currentEvent = EventInVillage.Flood;
		}
	}
}