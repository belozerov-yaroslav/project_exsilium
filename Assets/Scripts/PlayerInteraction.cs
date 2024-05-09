using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Inventory.Items_Classes;
using UnityEditor;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance { get; private set; }
    [SerializeField] private Collider2D _collider;
    private readonly HashSet<Item> _itemsInCollider = new();
    void Start()
    {
        if (instance != null)
            Debug.LogError("More than one PlayerInteraction in the scene");
        instance = this;
    }

    public ItemEnum[] GetNearItems()
    {
        return _itemsInCollider.Select(item => item.Enum).ToArray();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<ItemInteraction>(out var item))
            _itemsInCollider.Add(item.item);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<ItemInteraction>(out var item))
            _itemsInCollider.Remove(item.item);
    }
}
