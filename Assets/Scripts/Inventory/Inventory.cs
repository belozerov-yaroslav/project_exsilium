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
    
    private static readonly List<ItemSlot> InventorySlots = new();
    private int _indexCurrentItem = -1;
    private bool _isOpened = false;
    private bool _isItemSelected = false;
    
    private void Start()
    {
        for (var i = 0; i < transform.childCount ; i++)
        {
            InventorySlots.Add(transform.GetChild(i).GetComponent<ItemSlot>());
        }
        inventoryPanel.SetActive(_isOpened);
        CustomInputInitializer.CustomInput.Global.Inventory.performed += CloseOpenInventory;
        CustomInputInitializer.CustomInput.Global.Inventory.performed += InteractCurrentItem;
        CustomInputInitializer.CustomInput.Global.Inventory.performed += ChangeCurrentItem;
    }

    public void AddItem(Item newItem)
    {
        InventorySlots[newItem.itemId - 1].InsertItem(newItem);
    }
    
    public void CloseOpenInventory(InputAction.CallbackContext context)
    {
        if (!context.performed | context.control.name != "i") return;
        _isOpened = !_isOpened;
        inventoryPanel.SetActive(_isOpened);

    }

    public void InteractCurrentItem(InputAction.CallbackContext context)
    {
        if(!context.performed || context.control.name !="space" ||
           _indexCurrentItem == -1 || !_isItemSelected) return;
        InventorySlots[_indexCurrentItem - 1].Item.DoAction(); 
    }

    public void ChangeCurrentItem(InputAction.CallbackContext context)
    {
        if(!context.performed | !int.TryParse(context.control.name, out var keyNumber)) return;
        if (_indexCurrentItem == keyNumber) _isItemSelected = !_isItemSelected;
        else _isItemSelected = true;
        _indexCurrentItem = keyNumber;
    }
    
}

