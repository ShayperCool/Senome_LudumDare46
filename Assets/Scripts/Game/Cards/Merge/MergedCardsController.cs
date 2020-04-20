﻿using System.Collections.Generic;
using Extensions;
using Game.Models;

namespace Game.Cards.Merge {
	public static class MergedCardsController {

		private static readonly Dictionary<EventInVillage, HashSet<int>>  _solveTable = 
			new Dictionary<EventInVillage, HashSet<int>>();

		private static readonly HashSet<int> _cardsPatterns = new HashSet<int> {
			"ddd".SumOfChars(), 
			"sw".SumOfChars(), 
			"sr".SumOfChars(), 
			"rw".SumOfChars(), 
			"ss".SumOfChars(), 
			"we".SumOfChars(),
			"dds".SumOfChars(),
			"srw".SumOfChars(),
			"ddr".SumOfChars(),
			"dd".SumOfChars(),
			"ds".SumOfChars(),
			"dr".SumOfChars()
		};

		private static readonly HashSet<int> _advancedPatterns = new HashSet<int>() {
			"sr".SumOfChars()
		};
		
		private static readonly Dictionary<int, ActionInVillage> _actionsList = new Dictionary<int, ActionInVillage>();
		
		public static bool CanMerge(string pattern) {
			if (VillageController.Singleton.currentGameMode == VillageController.GameMode.Normal &&
			    _advancedPatterns.Contains(pattern.SumOfChars()))
				return false;
			return _cardsPatterns.Contains(pattern.SumOfChars());
		}
		
		static MergedCardsController() {
			_solveTable.Add(EventInVillage.Tornado,
				new HashSet<int>{
					"ddd".SumOfChars(),
					"sw".SumOfChars(),
					"sr".SumOfChars(),
				});
			_solveTable.Add(EventInVillage.Earthquake,
				new HashSet<int>{
					"rw".SumOfChars(),
				});
			_solveTable.Add(EventInVillage.Plague,
				new HashSet<int>{
					"ss".SumOfChars(),
				});
			_solveTable.Add(EventInVillage.Fire,
				new HashSet<int>{
					"we".SumOfChars(),
				});
			_solveTable.Add(EventInVillage.Flood,
				new HashSet<int>{
					"we".SumOfChars(),
				});
			_solveTable.Add(EventInVillage.Fog,
					new HashSet<int>{
						"sd".SumOfChars(),
					}
				);

			_actionsList.Add("dds".SumOfChars(), ActionInVillage.NewHumans);
			_actionsList.Add("srw".SumOfChars(), ActionInVillage.NewHumans);
			_actionsList.Add("drr".SumOfChars(), ActionInVillage.NewHumans);
		}
		
		public static void ProcessVillage(string pattern, Village village) {
			var  state = village.currentEvent;
			if (_solveTable.ContainsKey(state) && _solveTable[state].Contains(pattern.SumOfChars()))
				village.currentEvent = EventInVillage.None;
			
		}
		
	}
}