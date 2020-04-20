using System;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents {
	public class PlagueEventController : MonoBehaviour {
		
		public static PlagueEventController Singleton { get; private set; }
		public GameObject Plague;
		private bool _isRunning = false;
		
		private void Start() {
			Plague.SetActive(false);
			InitSingleton();
			VillageController.Singleton.OnEventInVillage += OnEventInVillage;
		}

		private void OnEventInVillage(EventInVillage eventInVillage) {
			
			if(eventInVillage == EventInVillage.Plague)
				OnEventStart();
			if(_isRunning && eventInVillage == EventInVillage.None)
				OnEventEnd();
		}

		private void OnEventStart() {
			_isRunning = true;
			Plague.SetActive(true);
		}


		private void OnEventEnd() {
			_isRunning = false;
			Plague.SetActive(false);
		}
		
		void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}
		
	}
}