using System;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents {
	public class FogEventController : MonoBehaviour {
		
		public static FogEventController Singleton { get; private set; }
		public GameObject Fog;
		private bool _isRunning = false;
		
		private void Start() {
			Fog.SetActive(false);
			InitSingleton();
			VillageController.Singleton.OnEventInVillage += OnEventInVillage;
		}

		private void OnEventInVillage(EventInVillage eventInVillage) {
			
			if(eventInVillage == EventInVillage.Fog)
				OnEventStart();
			if(_isRunning && eventInVillage == EventInVillage.None)
				OnEventEnd();
		}

		private void OnEventStart() {
			_isRunning = true;
			Fog.SetActive(true);
		}


		private void OnEventEnd() {
			_isRunning = false;
			Fog.SetActive(false);
		}
		
		void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}
		
	}
}