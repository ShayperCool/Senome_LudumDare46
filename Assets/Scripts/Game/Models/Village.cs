using UnityEngine;

namespace Game.Models {
	public class Village {
		public Sprite currentSky;
		public Sprite currentVillage;
		public int villagersCount;
		public State currentState;
		public float Coefficient { get => villagersCount / villagersOnStart; }
		public float villagersOnStart;

		public Village(int countOfVillagers) {
			villagersCount = countOfVillagers;
			villagersOnStart = countOfVillagers;
		}
		
		public enum State {
			Idle,
			Danger,
		}
	}
}