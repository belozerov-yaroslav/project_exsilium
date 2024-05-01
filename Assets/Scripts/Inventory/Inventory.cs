using System;
using System.Collections.Generic;
using Inventory.Items_Classes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public GameObject inventoryPanel;

        private static readonly List<ItemSlot> InventorySlots = new();
        private int _indexCurrentItem = -1;
        private bool _isOpened;
        private bool _isItemSelected;

        public static Inventory instance { get; private set; }

        private void Start()
        {
            if (instance != null)
                Debug.LogError("Find another inventory on the scene");
            instance = this;
            
            for (var i = 0; i < transform.childCount; i++)
            {
                InventorySlots.Add(transform.GetChild(i).GetComponent<ItemSlot>());
            }

            inventoryPanel.SetActive(_isOpened);
            CustomInputInitializer.CustomInput.Player.Inventory.performed += CloseOpenInventory;
            CustomInputInitializer.CustomInput.Player.Inventory.performed += ChangeCurrentItem;
            CustomInputInitializer.CustomInput.Player.ItemIteraction.performed += OnItemInteraction;
        }

        public void AddItem(Item newItem)
        {
            InventorySlots[(int)(newItem.Enum - 1)].InsertItem(newItem);
        }
        
        public void RemoveItem(Item removeItem)
        {
            InventorySlots.RemoveAt((int)(removeItem.Enum - 1));
            if (_indexCurrentItem == (int)(removeItem.Enum - 1))
            {
                _isItemSelected = false;
                _indexCurrentItem = -1;
            }
        }

        private void CloseOpenInventory(InputAction.CallbackContext context)
        {
            if (!context.performed | context.control.name != "i") return;
            _isOpened = !_isOpened;
            inventoryPanel.SetActive(_isOpened);
        }

        private void ChangeCurrentItem(InputAction.CallbackContext context)
        {
            if (!context.performed | !int.TryParse(context.control.name, out var keyNumber)) return;
            if (InventorySlots[keyNumber - 1].IsEmpty()) return;
            if (_indexCurrentItem == keyNumber - 1) _isItemSelected = !_isItemSelected;
            else
            {
                if (_indexCurrentItem != -1)
                    InventorySlots[_indexCurrentItem].TurnItem(false);

                _isItemSelected = true;
            }

            _indexCurrentItem = keyNumber - 1;
            InventorySlots[_indexCurrentItem].TurnItem(_isItemSelected);
        }
        
        private void OnItemInteraction(InputAction.CallbackContext obj)
        {
            if (!_isItemSelected) return;
            InventorySlots[_indexCurrentItem].Item.DoAction();
            if (InventorySlots[_indexCurrentItem].Item.IsDropable)
                RemoveItem(InventorySlots[_indexCurrentItem].Item);
        }
    }
}