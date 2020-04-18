using UnityEngine;

namespace Game.Models {
	public class Village {
		public Sprite CurrentSky { get; set; }
		public Sprite CurrentVillage { get; set; }
		public int VillagersCount { get; set; }
		public State CurrentState { get; set; }
		
		public enum State {
			Idle,
			Danger,
		}
	}
}