using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShopItemSO : ScriptableObject, IComparable<ShopItemSO>
{
    public Sprite iconItem;
    public int cost;

    public int CompareTo(ShopItemSO other)
    {
        if (cost < other.cost) { return -1; }
        return 1;
    }
}
