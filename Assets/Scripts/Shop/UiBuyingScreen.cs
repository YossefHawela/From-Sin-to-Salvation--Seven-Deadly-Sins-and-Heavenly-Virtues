using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiBuyingScreen : MonoBehaviour
{
    public static UiBuyingScreen Instance;

    [SerializeField]
    private GameObject Container;

    [SerializeField]
    private Image Itemimage;
    [SerializeField]
    private TextMeshProUGUI ItemPrice;
    [SerializeField]
    private BuyItem Buyitem;

    private void Awake()
    {
        Instance = this;
    }


    public void Show()
    {
        Container.SetActive(true);
    }

    public void Hide()
    {
        Container.SetActive(false);

    }


    public void SetItemAndShow(Item item)
    {
        Itemimage.sprite = item.GetSprite();
        ItemPrice.text = item.Price.ToString();
        Buyitem.item= item;

        Show();
    }
}
