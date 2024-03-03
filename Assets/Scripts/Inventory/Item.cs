using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    public enum ItemType 
    {
        Potato,
        Onion,
    }

    public ItemType Type;
    public int amount;

    public Sprite GetSprite() 
    {
        switch (Type) 
        {
            default: 
            case ItemType.Onion:  return ItemAssets.Instance.Onion;
            case ItemType.Potato: return ItemAssets.Instance.Potato;
        }
    }

    public bool isStackable() 
    {
        switch (Type) 
        {
            default:
            case ItemType.Potato:
            case ItemType.Onion:return true;
        }
    }
}
