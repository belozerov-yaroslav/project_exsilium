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
        public bool IsLocked;

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

            CustomInputInitializer.CustomInput.Player.ItemChange.performed += OnNumButtonPressed;
            CustomInputInitializer.CustomInput.Player.ItemIteraction.performed += OnItemInteraction;
            CustomInputInitializer.CustomInput.Player.ItemScroll.performed += OnMouseScroll;

            ItemInjector.instance?.Inject();
        }

        public void AddItem(Item newItem)
        {
            if (newItem.IsDropable && _itemsOnMap.Contains(newItem.ItemEnum))
                _itemsOnMap.Remove(newItem.ItemEnum);
            _inventorySlots[(int)(newItem.ItemEnum - 1)].InsertItem(newItem);
        }


        private void ChangeCurrentItem(int keyNumber)
        {
            if (_inventorySlots[keyNumber - 1].IsEmpty()) return;
            InventoryLearning.Instance?.OnItemPicked();
            ItemActionLearning.Instance?.TryStartLearning();
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

        private void OnNumButtonPressed(InputAction.CallbackContext callbackContext)
        {
            if (IsLocked)
                return;
            ChangeCurrentItem(int.Parse(callbackContext.control.name));
        }

        private void OnItemInteraction(InputAction.CallbackContext obj)
        {
            if (_indexCurrentItem == -1) return;
            ItemActionLearning.Instance?.OnItemAction();
            _inventorySlots[_indexCurrentItem].Item.DoAction();
            if (!_inventorySlots[_indexCurrentItem].Item.IsDropable) return;
            _itemsOnMap.Add(_inventorySlots[_indexCurrentItem].Item.ItemEnum);
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

        private void OnMouseScroll(InputAction.CallbackContext callbackContext)
        {
            if (IsLocked)
                return;
            if (callbackContext.ReadValue<float>() > 0)
            {
                if (_indexCurrentItem == -1)
                {
                    for (var i = 8; i >= 0; i--)
                    {
                        if (_inventorySlots[i].IsEmpty()) continue;
                        ChangeCurrentItem(i + 1);
                        break;
                    }
                }
                else
                {
                    for (var i = _indexCurrentItem - 1; i >= 0; i--)
                    {
                        if (_inventorySlots[i].IsEmpty()) continue;
                        ChangeCurrentItem(i + 1);
                        break;
                    }
                }
            }
            else
            {
                if (_indexCurrentItem == -1)
                {
                    for (var i = 0; i <= 8; i++)
                    {
                        if (_inventorySlots[i].IsEmpty()) continue;
                        ChangeCurrentItem(i + 1);
                        break;
                    }
                }
                else
                {
                    for (var i = _indexCurrentItem + 1; i <= 8; i++)
                    {
                        if (_inventorySlots[i].IsEmpty()) continue;
                        ChangeCurrentItem(i + 1);
                        break;
                    }
                }
            }
        }
    }
}