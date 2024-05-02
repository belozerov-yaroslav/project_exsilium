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

        public static Inventory Instance { get; private set; }

        private void Start()
        {
            if (Instance != null)
                Debug.LogError("Find another inventory on the scene");
            Instance = this;
            
            for (var i = 0; i < transform.childCount; i++)
            {
                InventorySlots.Add(transform.GetChild(i).GetComponent<ItemSlot>());
            }

            inventoryPanel.SetActive(_isOpened);
            CustomInputInitializer.CustomInput.Player.Inventory.performed += CloseOpenInventory;
            CustomInputInitializer.CustomInput.Player.ItemChange.performed += ChangeCurrentItem;
            CustomInputInitializer.CustomInput.Player.ItemIteraction.performed += OnItemInteraction;
        }

        public void AddItem(Item newItem)
        {
            InventorySlots[(int)(newItem.Enum - 1)].InsertItem(newItem);
        }

        private void CloseOpenInventory(InputAction.CallbackContext context)
        {
            _isOpened = !_isOpened;
            inventoryPanel.SetActive(_isOpened);
        }

        private void ChangeCurrentItem(InputAction.CallbackContext context)
        {
            var keyNumber = int.Parse(context.control.name);
            if (InventorySlots[keyNumber - 1].IsEmpty()) return;
            if (_indexCurrentItem == keyNumber - 1)
            {
                InventorySlots[_indexCurrentItem].TurnItem(false);
                _indexCurrentItem = -1;
            }
            else
            {
                if (_indexCurrentItem != -1)
                    InventorySlots[_indexCurrentItem].TurnItem(false);
                
                _indexCurrentItem = keyNumber - 1;
                InventorySlots[_indexCurrentItem].TurnItem(true);
            }
        }
        
        private void OnItemInteraction(InputAction.CallbackContext obj)
        {
            if (_indexCurrentItem == -1) return;
            InventorySlots[_indexCurrentItem].Item.DoAction();
            if (!InventorySlots[_indexCurrentItem].Item.IsDropable) return;
            InventorySlots[_indexCurrentItem].DeleteItem();
            _indexCurrentItem = -1;
        }
    }
}