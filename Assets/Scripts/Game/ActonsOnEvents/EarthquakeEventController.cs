using System;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents
{
	public class EarthquakeEventController : MonoBehaviour
	{

		public static EarthquakeEventController Singleton { get; private set; }

		private bool _isRunning = false;

		private void Start()
		{
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
			Debug.Log("Анимация Землетрясения");
		}


		private void OnEventEnd()
		{
			_isRunning = false;
			Debug.Log("Конец анимацииЗемлетрясения");
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