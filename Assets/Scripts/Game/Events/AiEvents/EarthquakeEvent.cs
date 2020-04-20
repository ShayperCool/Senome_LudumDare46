﻿using Game.Models;
using UnityEngine;

namespace Game.Events.AiEvents {
	public class EarthquakeEvent : IEventInVillage {
		public void ProcessVillage(Village village) {
			Debug.Log("Earthquake!!!");
			village.currentState = Village.State.Danger;
			village.currentEvent = EventInVillage.Earthquake;
		}
	}
}