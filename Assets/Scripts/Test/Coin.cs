using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ItemBase
{
    public override void GetItem()
    {
        Player.curentCoinnum += 1;
    }
}
