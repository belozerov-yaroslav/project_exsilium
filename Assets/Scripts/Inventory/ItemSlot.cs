using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private Image _image;

    public Item Item { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
    }

    public void InsertItem(Item newItem)
    {
        Item = newItem;
        _image.sprite = Item.itemIcon;
        _image.color = Color.white;
    }
}
