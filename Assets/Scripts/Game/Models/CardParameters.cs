using UnityEngine;

namespace Game.Models {
	[CreateAssetMenu(fileName = "New Card", menuName = "Create New Card", order = 0)]
	public class CardParameters : ScriptableObject {
		public Sprite Background { get; set; }
		public Sprite Foreground { get; set; }
		public string Description { get; set; }
		public string Title { get; set; }
	}
}