using Game.Models;
using UnityEngine;

namespace Game.Events {
	public class FogEvent : IEventInVillage {
		public void ProcessVillage(Village village) {
			Debug.Log("Fog!!!");
		}
	}
}