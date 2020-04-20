using System;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents {
	public class FloodEventController : MonoBehaviour {
		
		public static FloodEventController Singleton { get; private set; }
		public GameObject Flood;
		public Animator floodAnim;
		//public float speed;
		//public Vector3 startPosition, endPosition;
		private bool _isRunning = false;
		
		private void Start() {
			Flood.SetActive(false);
			InitSingleton();
			VillageController.Singleton.OnEventInVillage += OnEventInVillage;
		}

		private void OnEventInVillage(EventInVillage eventInVillage) {
			
			if(eventInVillage == EventInVillage.Flood)
				OnEventStart();
			if(_isRunning && eventInVillage == EventInVillage.None)
				OnEventEnd();
		}

		private void OnEventStart() {
			_isRunning = true;
			Flood.SetActive(true);
			floodAnim.SetTrigger("up");
		}


		private void OnEventEnd() {
			floodAnim.SetTrigger("down");
			_isRunning = false;
			Flood.SetActive(false);
		}
		
		void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}
		
	}
}