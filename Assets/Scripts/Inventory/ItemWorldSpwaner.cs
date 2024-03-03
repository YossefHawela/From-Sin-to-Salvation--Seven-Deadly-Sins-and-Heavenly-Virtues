using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpwaner : MonoBehaviour
{
    public Item item;

    private void Awake()
    {
        ItemWorld.SpawnItemWorld(this.gameObject.transform.position, item);
        Destroy(this.gameObject);
    }
}
