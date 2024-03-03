using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplete;
    private Player player;
     

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplete = itemSlotContainer.Find("ItemSlotTemplete");
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefershInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefershInventoryItems();
    }

    private void RefershInventoryItems() 
    {
        foreach (Transform child in itemSlotContainer) 
        {
            if (child == itemSlotTemplete) continue;
            Destroy(child.gameObject);
        }

        int x = 0 , y = 0;
        float itemSlotCellSize = 100f;

        foreach (Item item in inventory.GetItemList()) 
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplete, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => { };

            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => 
            {
                Item duplicateItem = new Item { Type = item.Type, amount = item.amount };
                inventory.RemoveItem(item);
                ItemWorld.DropItem(player.GetPosition(), duplicateItem);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2 (x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI textUI = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
                textUI.SetText(item.amount.ToString());
            else
                textUI.SetText ("");

            x++;
            if (x > 4) 
            {
                x = 0; 
                y++;
            }
        }
    }
}
