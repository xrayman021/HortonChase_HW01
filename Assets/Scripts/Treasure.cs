using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : CollectibleBase
{
    [SerializeField] int _treasureAmount = 0;

    protected override void Collect(Player player)
    {
        player.IncreaseTreasure(_treasureAmount);
    }
}
