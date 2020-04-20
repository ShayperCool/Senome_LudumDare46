using Game.Events;
using UnityEngine;

namespace Game.Models {
	public class Village {
		public Sprite currentSky;
		public Sprite currentVillage;
		public int villagersCount;
		public State currentState = State.Idle;
		public EventInVillage currentEvent = EventInVillage.None;
		public bool canceledByCombo = false;
		public float Coefficient => villagersCount / _villagersOnStart;
		private readonly float _villagersOnStart;

		public Village(int countOfVillagers) {
			villagersCount = countOfVillagers;
			_villagersOnStart = countOfVillagers;
		}
		
		public enum State {
			Idle,
			Danger,
		}
	}
}