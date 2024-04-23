using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    
    private static readonly List<Item > InventorySlots = new List<Item >();
    private int _indexCurrentItem = -1;
    private bool _isOpened = false;
    
    private void Start()
    {
        for (var i = 0; i < transform.childCount ; i++)
        {
            InventorySlots.Add(transform.GetChild(i).GetComponent<Item>());
        }
        inventoryPanel.SetActive(_isOpened);
    }
    

    public void CloseOpenInventory(InputAction.CallbackContext context)
    {
        if (!context.performed | context.control.name != "i") return;
        _isOpened = !_isOpened;
        inventoryPanel.SetActive(_isOpened);

    }

    private void InteractCurrentItem()
    {
        if(_indexCurrentItem == -1) return;
        InventorySlots[_indexCurrentItem - 1].DoAction();   
    }

    public void ChangeCurrentItem(InputAction.CallbackContext context)
    {
        if(!context.performed | !int.TryParse(context.control.name, out var keyNumber)) return;
        if (_indexCurrentItem == keyNumber)
        {
            _indexCurrentItem = -1;
            return;
        }

        _indexCurrentItem = keyNumber;
        InteractCurrentItem();
    }
    
}

