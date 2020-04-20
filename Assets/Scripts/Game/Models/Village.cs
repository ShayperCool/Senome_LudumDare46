using Game.Events;
using UnityEngine;

namespace Game.Models {
	public class Village {
		public Sprite currentSky;
		public Sprite currentVillage;

		public int villagersCount {
			get {
				if (_villagersCount < 0) {
					GameManager.Singleton.GameOver();
					return 0;
				}
				return _villagersCount;
			} 
			set {
				_villagersCount = value;
			}
		}

		private int _villagersCount = 0;
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