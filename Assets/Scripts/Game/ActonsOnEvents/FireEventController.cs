using System;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents {
	public class FireEventController : MonoBehaviour {
		
		public static FireEventController Singleton { get; private set; }

		private bool _isRunning = false;
		
		private void Start() {
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
			
		}


		private void OnEventEnd() {
			_isRunning = false;
			
		}
		
		void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}
		
	}
}