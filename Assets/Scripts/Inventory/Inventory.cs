using System.Collections.Generic;
using Inventory.Items_Classes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public GameObject inventoryPanel;
        [SerializeField] public CustomInputInitializer input;
    
        private static readonly List<ItemSlot > InventorySlots = new List<ItemSlot >();
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
            input.CustomInput.Global.Inventory.performed += CloseOpenInventory;
            input.CustomInput.Global.Inventory.performed += InteractCurrentItem;
            input.CustomInput.Global.Inventory.performed += ChangeCurrentItem;
        }

        public void AddItem(Item newItem)
        {
            InventorySlots[newItem.ItemId - 1].InsertItem(newItem);
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
            InventorySlots[_indexCurrentItem].Item.DoAction();   
        }

        public void ChangeCurrentItem(InputAction.CallbackContext context)
        {
            if(!context.performed | !int.TryParse(context.control.name, out var keyNumber)) return;
            if(InventorySlots[keyNumber - 1].IsEmpty()) return;
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
    
    }
}

