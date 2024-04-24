using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : MonoBehaviour
{
    private static Dictionary<int, string> _actions = new Dictionary<int, string>()
    {
        {1,"нож подействовал"},
        {2,"свеча действие"},
        {3,"крест действие"},
        {4,"икона действие"},
        {5,"травы действие"},
        {6,"благовония действие"},
        {7,"молитвенник действие"},
        {8,"мел действие"},
    };

    public int itemId;
    [FormerlySerializedAs("ItemIcon")] public Sprite itemIcon;

    private void Start()
    {
        itemIcon = GetComponent<SpriteRenderer>().sprite;
    }

    public void DoAction()
    {
        Debug.Log(_actions[itemId]);
    }
}
