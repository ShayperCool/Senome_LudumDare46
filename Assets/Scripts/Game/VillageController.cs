using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Models;
using Random = UnityEngine.Random;

namespace Game {
	public class VillageController : MonoBehaviour {
		public static VillageController Singleton { get; private set; }
		public Village villageState;
		public int maxStartVillagers = 100;
		public int minStartVillagers = 50;
		public event Action<int> OnStateChange;

		private bool _isJumped = false;
		
		private void Start() {
			InitSingleton();
			InitVillage();
		}

		private void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}

		private void InitVillage() {
			villageState = new Village();
			villageState.VillagersCount = Random.Range(minStartVillagers, maxStartVillagers);
		}
		

		//Process current state in card or some action object
		public void ProcessAction(IEventInVillage eventInVillage) {
			eventInVillage.ProcessVillage(villageState);
			OnStateChange?.Invoke(0);
		}
	}
}