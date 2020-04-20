using System;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents {
	public class TornadoEventController : MonoBehaviour {
		
		public static TornadoEventController Singleton { get; private set; }

		private bool _isRunning = false;
		
		private void Start() {
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
		}


		private void OnEventEnd() {
			_isRunning = false;
			Debug.Log("Конец Анимации Торнадо");
		}
		
		void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}
		
	}
}