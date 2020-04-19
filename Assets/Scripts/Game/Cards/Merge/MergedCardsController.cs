using System.Collections.Generic;
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
		};
		
		public static bool CanMerge(string pattern) {
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
			_solveTable.Add(EventInVillage.AddHumans,
				new HashSet<int>{
					"dds".SumOfChars(),
					"srw".SumOfChars(),
					"drr".SumOfChars(),
				});
		}
		
		public static void ProcessVillage(string pattern, Village village) {
			EventInVillage state = village.currentEvent;
			if (_solveTable[state].Contains(pattern.SumOfChars()))
				village.currentEvent = EventInVillage.None;
		}
		
	}
}