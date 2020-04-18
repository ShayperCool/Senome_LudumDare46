using Game.Models;
using UnityEngine;

namespace Game.Events {
	public class EarthquakeEvent : IEventInVillage {
		public void ProcessVillage(Village village) {
			Debug.Log("Earthquake!!!");
		}
	}
}