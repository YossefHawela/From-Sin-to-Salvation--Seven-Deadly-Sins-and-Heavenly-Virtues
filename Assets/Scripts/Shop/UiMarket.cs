using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMarket : MonoBehaviour
{
    public static UiMarket Instance;

    [SerializeField]
    private GameObject Container;

    

    private void Awake()
    {
        Instance= this;
    }

    public void Show()
    {
        Container.SetActive(true);
    }

    public void Hide()
    {
        Container.SetActive(false);
    }

    public void OpenBuyMenu(BuyItem item)
    {
        UiBuyingScreen.Instance.SetItemAndShow(item.item);
    }
}
