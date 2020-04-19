using Game.Cards;

namespace Game.Models {
	public interface IMergeCard {
		bool CanMerge(CardBase card);
	}
}