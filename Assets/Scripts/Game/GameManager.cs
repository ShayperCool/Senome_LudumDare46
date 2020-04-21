using System;
using Game.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class GameManager : MonoBehaviour {

		public static GameManager Singleton;
		public GameObject panelFinish, panelGameOver;
		public Text text;
		
		public void Start() {
			Singleton = this;
			Time.timeScale = 1f;
			panelFinish.SetActive(false);
			panelGameOver.SetActive(false);
		}


		public void GameOver() {
			Time.timeScale = 0f;
			StandardEvents.GameStop.Cancel();
			Debug.Log("Игра закончена");
			panelGameOver.SetActive(true);
		}
		
		public void FinishGame()
		{
			Time.timeScale = 0f;
			StandardEvents.GameStop.Cancel();
			Debug.Log("Игра закончена");
		}


	}
}