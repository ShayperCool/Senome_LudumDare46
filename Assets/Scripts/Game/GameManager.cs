using System;
using UnityEngine;

namespace Game {
	public class GameManager : MonoBehaviour {

		public static GameManager Singleton;
		
		
		public void Start() {
			Singleton = this;
			Time.timeScale = 1f;
		}

		public void GameOver() {
			Time.timeScale = 0f;
			Debug.Log("Игра закончена");
		}
		
		
		
	}
}