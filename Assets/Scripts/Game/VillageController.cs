using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Events;
using UnityEngine;
using Game.Models;
using Random = UnityEngine.Random;

namespace Game {
	public class VillageController : MonoBehaviour {
		public static VillageController Singleton { get; private set; }
		
		public Village village;
		public int maxStartVillagers = 250;
		public int minStartVillagers = 200;
		public event Action<Village.State> OnEventInVillage;
		public event Action OnStateChange;

		private void Awake() {
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
			village = new Village(Random.Range(minStartVillagers, maxStartVillagers));
			StandardEvents.Start(village);
			
		}
		

		//Process current state in card or some action object
		public void ProcessEventOrCard(IEventInVillage eventInVillage) {
			var stateBefore = village.currentState;
			eventInVillage.ProcessVillage(village);
			
			if (village.currentEvent == EventInVillage.None)
				village.currentState = Village.State.Idle;
			
			if(stateBefore != village.currentState && stateBefore == Village.State.Idle)
				StandardEvents.GrowUpCancelToken.Cancel();
			
			OnEventInVillage?.Invoke(village.currentState);
		}
		
		
		private void OnDestroy() {
			StandardEvents.GameStop.Cancel();
		}
	}
}