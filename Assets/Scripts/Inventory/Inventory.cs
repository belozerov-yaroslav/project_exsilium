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
        public GameObject inventoryPanel;

        private readonly List<ItemSlot> InventorySlots = new(9);
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
                InventorySlots.Add(transform.GetChild(i).GetComponent<ItemSlot>());
            }
            
            CustomInputInitializer.CustomInput.Player.ItemChange.performed += ChangeCurrentItem;
            CustomInputInitializer.CustomInput.Player.ItemIteraction.performed += OnItemInteraction;
            
            ItemInjector.instance?.Inject();
        }

        public void AddItem(Item newItem)
        {
            if (newItem.IsDropable && _itemsOnMap.Contains(newItem.Enum))
                _itemsOnMap.Remove(newItem.Enum);
            InventorySlots[(int)(newItem.Enum - 1)].InsertItem(newItem);
            if (InventorySlots.Select(x => x.Item).All(x => x != null)) InventoryFilled?.Invoke();
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
            _itemsOnMap.Add(InventorySlots[_indexCurrentItem].Item.Enum);
            InventorySlots[_indexCurrentItem].DeleteItem();
            _indexCurrentItem = -1;
        }
        public event Action InventoryFilled;

        public ItemEnum[] GetItemsOnMap()
        {
            return _itemsOnMap.ToArray();
        }
    }
}