using System;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents {
	public class TornadoEventController : MonoBehaviour {
		
		public static TornadoEventController Singleton { get; private set; }
		public GameObject Tornado;
		private bool _isRunning = false;
		
		private void Start() {
			Tornado.SetActive(false);
			InitSingleton();
			VillageController.Singleton.OnEventInVillage += OnEventInVillage;
		}

		private void OnEventInVillage(EventInVillage eventInVillage) {
			
			if(eventInVillage == EventInVillage.Tornado)
				OnEventStart();
			if(_isRunning && eventInVillage == EventInVillage.None)
				OnEventEnd();
		}

		private void OnEventStart() {
			_isRunning = true;
			Debug.Log("Анимация Торнадо");
			Tornado.SetActive(true);
		}


		private void OnEventEnd() {
			_isRunning = false;
			Debug.Log("Конец Анимации Торнадо");
			Tornado.SetActive(false);
		}
		
		void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}
		
	}
}