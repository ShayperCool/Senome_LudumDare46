﻿using Game.Models;
using UnityEngine;

namespace Game.Events {
	public class PlagueEvent : IEventInVillage{
		public void ProcessVillage(Village village) {
			Debug.Log("Plague!!!");
		}
	}
}