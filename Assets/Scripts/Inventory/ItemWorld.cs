using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.Diagnostics;

public class ItemWorld : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Item item;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item) 
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();

        if (item.amount > 1)
            textMeshPro.SetText(item.amount.ToString());
        else
            textMeshPro.SetText("");
    }

    public static ItemWorld SpawnItemWorld(Vector3 posistion, Item item) 
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, posistion, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item) 
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * 5f, item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 5f, ForceMode2D.Impulse);

        return itemWorld;
    }

    public Item GetItem() => item;

    public void DestroySelf() => Destroy(gameObject);
}
