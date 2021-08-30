using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    [SerializeField] int _treasureAmount = 0;

    protected override void Collect(Player player)
    {
        player.IncreaseTreasure(_treasureAmount);
    }
}
