using Game.Models;
using UnityEngine;

namespace Game.Events.AiEvents {
	public class TornadoEvent : IEventInVillage{
		public void ProcessVillage(Village village) {
			Debug.Log("Tornado!!!");
			village.currentState = Village.State.Danger;
			village.currentEvent = EventInVillage.Tornado;
		}
	}
}