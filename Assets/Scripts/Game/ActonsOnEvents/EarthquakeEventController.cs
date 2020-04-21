using System;
using Game.Actions;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents
{
	public class EarthquakeEventController : MonoBehaviour
	{

		public static EarthquakeEventController Singleton { get; private set; }


		public GameObject Earthquake;
		public GameObject cameraEarthquake;
		public Animator anim;

		private bool _isRunning = false;

		private void Start()
		{
			Earthquake.SetActive(false);
			anim.enabled = false;


			InitSingleton();
			VillageController.Singleton.OnEventInVillage += OnEventInVillage;
		}

		private void OnEventInVillage(EventInVillage eventInVillage)
		{

			if (eventInVillage == EventInVillage.Earthquake)
				OnEventStart();
			if (_isRunning && eventInVillage == EventInVillage.None)
				OnEventEnd();
		}

		private void OnEventStart()
		{
			_isRunning = true;
			EarthQuakeShake.Singleton.shake = true;
			Earthquake.SetActive(true);
			anim.enabled = true;

		}


		private void OnEventEnd()
		{
			_isRunning = false;
			EarthQuakeShake.Singleton.UnShake();
			if (VillageController.Singleton.village.canceledByCombo) {
				//Действия
			}
			Earthquake.SetActive(false);
			anim.enabled = false;
		}

		void InitSingleton()
		{
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}

	}
}