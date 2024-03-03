using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public static Inventory Instance;
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        Instance = this;
        itemList = new List<Item>();

        //AddItem(new Item { Type = Item.ItemType.Potato, amount = 1});
        //AddItem(new Item { Type = Item.ItemType.Onion, amount = 1 });
    }

    public void AddItem(Item item) 
    {
        if (item.isStackable()) 
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList) 
            {
                if (inventoryItem.Type == item.Type) 
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) 
            {
                itemList.Add(item);
            }
        }
        else 
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item) 
    {
        if (item.isStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.Type == item.Type)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList() 
    {
        return itemList;
    }
}
