using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    private Item _item;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void AddItem(Item newItem)
    {
        _item = newItem;
        _image.sprite = _item.ItemSprite;
    }
}
