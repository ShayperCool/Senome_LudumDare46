using System;
using UnityEngine;
using Game.Models;

namespace Game {
	public class VillageController : MonoBehaviour {

		public static VillageController Singleton { get; private set; }
		public Village villageState;
		public event Action<int> OnStateChange;
		
		private void Start() {
			InitSingleton();
		}

		private void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}

		private void InitVillage() {
			villageState = new Village();
			//TODO: Сделать стандартные парметры мб какая-то рандомная генерация для деревни
		}
		
		//Process current state in card or some action object
		public void ProcessAction(IEventInVillage eventInVillage) {
			eventInVillage.ProcessVillage(villageState);
			OnStateChange?.Invoke(0);
		}
	}
}