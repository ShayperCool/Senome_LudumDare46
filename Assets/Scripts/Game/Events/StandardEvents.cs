using System;
using System.Threading;
using System.Threading.Tasks;
using Game.Events.AiEvents;
using Game.Events.PlayerEvents;
using Game.Models;
using Ui.Game;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Events {
	//Class with all standard effects
	public static class StandardEvents {
		
		//Token will be cancelled just on end of game 
		public static CancellationTokenSource GameStop;
		public static int NumberMovesUntilTheEndGame = 12;
		//For cancel growUp Task.Delay
		public static CancellationTokenSource GrowUpCancelToken;
		private static Array _enumElements;
		private static Village _village;
		

		public static void Start(Village village) {
			GameStop = new CancellationTokenSource();
			_enumElements = Enum.GetValues(typeof(EventInVillage));
			_village = village;
			GrowUpCancelToken = new CancellationTokenSource();
			GrowUp();
			RandomEventSpawn();

			int _mode = PlayerPrefs.GetInt("game_mode");
			//if (_mode == 0) NumberMovesUntilTheEndGame = CardsContainer.Singleton.numberMovesSimple;
			//else NumberMovesUntilTheEndGame = CardsContainer.Singleton.numberMovesMedium;
		}
		
		private static async void GrowUp() {
			while (true) {
				int delay = _village.currentState == Village.State.Idle ? 5000 : 1000;
				await Task.Delay(delay);
				//On end of game cancel
				if (GameStop.IsCancellationRequested)
					return;
				if(_village.currentState == Village.State.Idle)
					VillageController.Singleton.ProcessEventOrCard(new GrowUpEvent());
				else
					VillageController.Singleton.ProcessEventOrCard(new DeathEvent());
			}
		}

		private static async void RandomEventSpawn() {
			while (true)
			{
				await Task.Delay(Random.Range(3000, 7000));
				if (GameStop.IsCancellationRequested || NumberMovesUntilTheEndGame == 0)
					return;

				if (_village.currentState == Village.State.Danger)
					continue;
				var inVillageEvent = (EventInVillage)_enumElements.GetValue(Random.Range(0, _enumElements.Length));
				VillageController.Singleton.ProcessEventOrCard(GetEvent(inVillageEvent));
				NumberMovesUntilTheEndGame--;
			}
		}
		
		private static IEventInVillage GetEvent(EventInVillage eventInVillage) {
			// switch (eventInVillage) {
			// 	case EventInVillage.Fire:
			// 		return new FireEvent();
			// 	case EventInVillage.Flood:
			// 		return new FloodEvent();
			// 	case EventInVillage.Plague:
			// 		return new PlagueEvent();
			// 	case EventInVillage.Fog:
			// 		return new FogEvent();
			// 	case EventInVillage.Earthquake:
			// 		return new EarthquakeEvent();
			// 	case EventInVillage.None:
			// 		return new NoneEvent();
			// 	case EventInVillage.Tornado:
				return new TornadoEvent();
			// 	default:
			// 		throw new ArgumentOutOfRangeException();
			// }
		}
	}
}