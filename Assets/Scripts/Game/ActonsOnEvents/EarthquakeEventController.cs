using System;
using Game.Models;
using UnityEngine;

namespace Game.ActonsOnEvents
{
	public class EarthquakeEventController : MonoBehaviour
	{

		public static EarthquakeEventController Singleton { get; private set; }


		public GameObject Earthquake;
		public GameObject cameraEarthquake;
		public float forceEarthquake;
		private Vector3 _startPosition;
		private float _currentForce = 0;

		private bool _isRunning = false;

		private void Start()
		{
			Earthquake.SetActive(false);
			_startPosition = cameraEarthquake.transform.position;


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
			Earthquake.SetActive(true);

			//while (_isRunning)
			//{
			//	if (_currentForce <= 0 && _currentForce != -forceEarthquake) _currentForce -= 0.1f;
			//	if (_currentForce > 0 && _currentForce != forceEarthquake) _currentForce += 0.1f;
				
			//	Vector3 newPosition = _startPosition;
			//	newPosition.y += _currentForce;
			//	cameraEarthquake.transform.position = newPosition;
			//}			
		}


		private void OnEventEnd()
		{
			_isRunning = false;
			Earthquake.SetActive(false);
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