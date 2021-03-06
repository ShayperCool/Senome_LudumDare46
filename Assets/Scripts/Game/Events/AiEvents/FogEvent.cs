﻿using Game.Models;
using UnityEngine;

namespace Game.Events.AiEvents {
	public class FogEvent : IEventInVillage {
		public void ProcessVillage(Village village) {
			Debug.Log("Fog!!!");
			village.currentState = Village.State.Danger;
			village.currentEvent = EventInVillage.Fog;
		}
	}
}