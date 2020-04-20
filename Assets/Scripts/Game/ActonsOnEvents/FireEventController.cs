using System;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents {
	public class FireEventController : MonoBehaviour {
		
		public static FireEventController Singleton { get; private set; }
		public GameObject Fire;
		private bool _isRunning = false;
		
		private void Start() {
			Fire.SetActive(false);
			InitSingleton();
			VillageController.Singleton.OnEventInVillage += OnEventInVillage;
		}

		private void OnEventInVillage(EventInVillage eventInVillage) {
			
			if(eventInVillage == EventInVillage.Fire)
				OnEventStart();
			if(_isRunning && eventInVillage == EventInVillage.None)
				OnEventEnd();
		}

		private void OnEventStart() {
			_isRunning = true;
			Debug.Log("Анимация огня");
			Fire.SetActive(true);
		}


		private void OnEventEnd() {
			_isRunning = false;
			Debug.Log("Конец анимации огня");
			Fire.SetActive(false);
		}
		
		void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}
		
	}
}