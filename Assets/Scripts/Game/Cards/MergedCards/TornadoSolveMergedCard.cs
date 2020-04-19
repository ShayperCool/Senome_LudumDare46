using Game.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Cards
{
    public class TornadoSolveMergedCard : CardBase
    {
        public override bool CanMerge(CardBase card)
        {
            throw new System.NotImplementedException();
        }

        protected override void ProcessVillageByCard(Village village)
        {
            if(village.currentEvent == InVillageEvent.Tornado)
            {
                village.currentEvent = InVillageEvent.None;
            }
        }
    }
}

