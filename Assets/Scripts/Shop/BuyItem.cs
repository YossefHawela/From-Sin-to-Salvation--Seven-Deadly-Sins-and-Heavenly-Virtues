using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    

    public Item item;
    public void Buy()
    {
        if (Player.Instance.Coins >= item.Price)
        {
            Inventory.Instance.AddItem(item);


            Player.Instance.Coins -= item.Price;

        }
            UiBuyingScreen.Instance.Hide();
    }

}
