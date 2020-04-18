using System;
using Game;
using Game.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Game {
	public class GameUi : MonoBehaviour {

		public Text villagersCount;


		private void Start() {
			VillageController.Singleton.OnEventInVillage += OnEventInVillage;
			UpdateValues();
		}

		private void UpdateValues() {
			villagersCount.text = "Villagers: \n" + VillageController.Singleton.village.villagersCount;
		}
		
		private void OnEventInVillage(Village.State state) {
			UpdateValues();
		}
		
	}
}