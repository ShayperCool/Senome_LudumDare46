using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Models;

public class BuyCardEvent : IEventInVillage
{
    public void ProcessVillage(Village village)
    {
        village.villagersCount -= 5;
    }
}
