using System;
using Game.Models;

namespace Game.Actions {
	public static class ActionsController {
		public static void ExecuteAction(ActionInVillage action) {
			VillageController.Singleton.ProcessEventOrCard(GetAction(action));
		}

		private static IEventInVillage GetAction(ActionInVillage action) {
			switch (action) {
				case ActionInVillage.NewHumans:
					return new NewHumansAction();
				default:
					throw new ArgumentOutOfRangeException(nameof(action), action, null);
			}
		}
		
	}
}