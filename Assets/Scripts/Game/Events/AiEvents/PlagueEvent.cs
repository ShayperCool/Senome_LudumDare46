﻿using Game.Models;
using UnityEngine;

namespace Game.Events.AiEvents {
	public class PlagueEvent : IEventInVillage{
		public void ProcessVillage(Village village) {
			Debug.Log("Plague!!!");
			village.currentState = Village.State.Danger;
			village.currentEvent = EventInVillage.Plague;
		}
	}
}