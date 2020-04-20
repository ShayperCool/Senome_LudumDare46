using Game.Models;

namespace Game.Events.PlayerEvents {
    public class BuyCardEvent : IEventInVillage
    {
        public void ProcessVillage(Village village)
        {
            village.villagersCount -= 5;
        }
    }
}
