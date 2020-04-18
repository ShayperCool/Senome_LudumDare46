using System;
using System.Threading;
using System.Threading.Tasks;
using Game.Models;
using Random = UnityEngine.Random;

namespace Game.Events {
	//Class with all standard effects
	public static class StandardEvents {
		
		//Token will be cancelled just on end of game 
		public static CancellationTokenSource CancellationTokenSource;
		private static Array _enumElements;
		
		public static void Start() {
			CancellationTokenSource = new CancellationTokenSource();
			_enumElements = Enum.GetValues(typeof(InVillageEvent));
			GrowUp();
			RandomEventSpawn();
		}
		
		private static async void GrowUp() {
			while (true) {
				await Task.Delay(5000);
				if (CancellationTokenSource.IsCancellationRequested)
					return;
				VillageController.Singleton.ProcessAction(new GrowUpEvent());
			}
		}

		private static async void RandomEventSpawn() {
			while (true) {
				await Task.Delay(Random.Range(3000, 7000));
				if (CancellationTokenSource.IsCancellationRequested)
					return;
				var inVillageEvent = (InVillageEvent)_enumElements.GetValue(Random.Range(0, _enumElements.Length));
				VillageController.Singleton.ProcessAction(GetEvent(inVillageEvent));
			}
		}
		
		private static IEventInVillage GetEvent(InVillageEvent inVillageEvent) {
			switch (inVillageEvent) {
				case InVillageEvent.Fire:
					return new FireEvent();
				case InVillageEvent.Flood:
					return new FloodEvent();
				case InVillageEvent.Plague:
					return new PlagueEvent();
				case InVillageEvent.Fog:
					return new FogEvent();
				case InVillageEvent.Earthquake:
					return new EarthquakeEvent();
				default:
					throw new ArgumentOutOfRangeException();
			}
			
		}
		
	}
}