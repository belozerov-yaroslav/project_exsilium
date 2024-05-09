using System.Collections;
using System.Collections.Generic;
using Inventory.Items_Classes;
using UnityEngine;

public class ItemSoundsScript : MonoBehaviour
{
    public static Dictionary<ItemEnum, AudioSource> ItemSounds = new Dictionary<ItemEnum, AudioSource>();
    void Start()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var itemInteractionElem = transform.GetChild(i).GetComponent<ItemInteractionClass>();
            ItemSounds[itemInteractionElem.itemEnum] = itemInteractionElem.itemInteractionSound;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
