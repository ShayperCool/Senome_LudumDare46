﻿using Game.Models;
using UnityEngine;

namespace Game.Events {
	public class FloodEvent : IEventInVillage {
		public void ProcessVillage(Village village) {
			Debug.Log("Flood!!");
		}
	}
}