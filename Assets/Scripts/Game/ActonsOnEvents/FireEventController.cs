using System;
using System.Collections;
using Game.Models;
using UnityEngine;
using Game;

namespace Game.ActonsOnEvents {
	public class FireEventController : MonoBehaviour {
		
		public static FireEventController Singleton { get; private set; }
		public GameObject Fire;
		private bool _isRunning = false;
		[SerializeField] private GameObject _rainGameObject;
		public event Action OnEndFire;

		private void Awake()
		{
			InitSingleton();
		}
		private void Start() {
			Fire.SetActive(false);
			VillageController.Singleton.OnEventInVillage += OnEventInVillage;
		}

		private void OnEventInVillage(EventInVillage eventInVillage) {
			
			if(eventInVillage == EventInVillage.Fire)
				OnEventStart();
			if(_isRunning && eventInVillage == EventInVillage.None)
				OnEventEnd();
		}

		private void OnEventStart() {
			_isRunning = true;			Fire.SetActive(true);
		}


		private void OnEventEnd() {
			_isRunning = false;
			Fire.SetActive(false);
			if (VillageController.Singleton.village.canceledByCombo) //Combo cards
			{
				OnEndFire?.Invoke();
				VillageController.Singleton.village.canceledByCombo = false;
			}
			else //Single card
			{
				StartCoroutine(StartRaining());
			}

		}
		
		void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}
		private IEnumerator StartRaining()
		{
			_rainGameObject.SetActive(true);
			yield return new WaitForSeconds(5);
			_rainGameObject.SetActive(false);
		}
		
	}
}