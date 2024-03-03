using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    public enum ItemType 
    {
        PotatoSeeds,
        Potato,
        Onion,
    }

    public ItemType Type;
    public float Price = 200;
    public int amount;

    public Sprite GetSprite() 
    {
        switch (Type) 
        {
            default: 
            case ItemType.Onion:  return ItemAssets.Instance.Onion;
            case ItemType.Potato: return ItemAssets.Instance.Potato;
            case ItemType.PotatoSeeds: return ItemAssets.Instance.PotatoSeeds;
        }
    }

    public bool isStackable() 
    {
        switch (Type) 
        {
            default:
            case ItemType.Potato:
            case ItemType.PotatoSeeds:
            case ItemType.Onion:return true;

        }
    }
}
