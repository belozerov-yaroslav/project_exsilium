using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static readonly List<InventorySlot > InventorySlots = new List<InventorySlot>();
    private static int _nextFreeSlot = 0;
    
    private void Start()
    {
        for (var i = 0; i < transform.childCount ; i++)
        {
            InventorySlots.Add(transform.GetChild(i).GetComponent<InventorySlot>());
        }
    }

    public static void AddItem(Item newItem)
    {
        if(_nextFreeSlot >= InventorySlots.Count) return;
        InventorySlots[_nextFreeSlot].AddItem(newItem);
        _nextFreeSlot++;
    }
}

