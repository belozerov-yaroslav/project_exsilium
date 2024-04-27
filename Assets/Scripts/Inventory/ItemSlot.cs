using System.Collections;
using System.Collections.Generic;
using Inventory.Items_Classes;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private Image _itemImage;
    private Image _outlineImage;

    private readonly Color _backgroundColor = new (80 / 255f, 80 / 255f, 80 / 255f, 1);
    private readonly Color _outlineColor = new (175 / 255f, 175 / 255f, 175 / 255f, 1);

    public Item Item { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _itemImage = transform.GetChild(1).GetComponent<Image>();
        _outlineImage = GetComponent<Image>();
    }

    public void InsertItem(Item newItem)
    {
        Item = newItem;
        _itemImage.sprite = Item.ItemIcon;
        _itemImage.color = Color.white;
    }

    public void TurnItem(bool isSelected) => _outlineImage.color = isSelected ? _outlineColor : _backgroundColor;
    
    public bool IsEmpty() => Item == null;
}