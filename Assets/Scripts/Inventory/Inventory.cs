using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Items_Classes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        private readonly List<ItemSlot> _inventorySlots = new(9);
        private int _indexCurrentItem = -1;
        private bool _isOpened;

        private readonly HashSet<ItemEnum> _itemsOnMap = new(); 

        public static Inventory Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
                Debug.LogError("Find another inventory on the scene");
            Instance = this;
        }

        private void Start()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                _inventorySlots.Add(transform.GetChild(i).GetComponent<ItemSlot>());
            }
            
            CustomInputInitializer.CustomInput.Player.ItemChange.performed += ChangeCurrentItem;
            CustomInputInitializer.CustomInput.Player.ItemIteraction.performed += OnItemInteraction;
            
            ItemInjector.instance?.Inject();
        }

        public void AddItem(Item newItem)
        {
            if (newItem.IsDropable && _itemsOnMap.Contains(newItem.Enum))
                _itemsOnMap.Remove(newItem.Enum);
            _inventorySlots[(int)(newItem.Enum - 1)].InsertItem(newItem);
        }
        

        private void ChangeCurrentItem(InputAction.CallbackContext context)
        {
            var keyNumber = int.Parse(context.control.name);
            if (_inventorySlots[keyNumber - 1].IsEmpty()) return;
            InventoryLearning.Instance?.OnItemPicked();
            if (_indexCurrentItem == keyNumber - 1)
            {
                _inventorySlots[_indexCurrentItem].TurnItem(false);
                _indexCurrentItem = -1;
            }
            else
            {
                if (_indexCurrentItem != -1)
                    _inventorySlots[_indexCurrentItem].TurnItem(false);
                
                _indexCurrentItem = keyNumber - 1;
                _inventorySlots[_indexCurrentItem].TurnItem(true);
            }
        }
        
        private void OnItemInteraction(InputAction.CallbackContext obj)
        {
            if (_indexCurrentItem == -1) return;
            _inventorySlots[_indexCurrentItem].Item.DoAction();
            if (!_inventorySlots[_indexCurrentItem].Item.IsDropable) return;
            _itemsOnMap.Add(_inventorySlots[_indexCurrentItem].Item.Enum);
            _inventorySlots[_indexCurrentItem].DeleteItem();
            _indexCurrentItem = -1;
        }

        public bool IsFullInventory()
        {
            return !_inventorySlots.Any(slot => slot.IsEmpty());
        }
        

        public ItemEnum[] GetItemsOnMap()
        {
            return _itemsOnMap.ToArray();
        }
    }
}