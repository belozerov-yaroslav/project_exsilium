using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Inventory.Items_Classes;
using UnityEditor;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction Instance { get; private set; }
    [SerializeField] private Collider2D _collider;
    private readonly HashSet<Item> _itemsInCollider = new();
    void Start()
    {
        if (Instance != null)
            Debug.LogError("More than one PlayerInteraction in the scene");
        Instance = this;
    }
    
    private void OnDestroy()
    {
        Instance = null;
    }

    public ItemEnum[] GetNearItems()
    {
        return _itemsInCollider.Select(item => item.ItemEnum).ToArray();
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
