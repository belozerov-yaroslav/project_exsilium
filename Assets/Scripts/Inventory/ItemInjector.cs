using System;
using System.Collections;
using System.Collections.Generic;
using Inventory.Items_Classes;
using UnityEditor;
using UnityEngine;

public class ItemInjector : MonoBehaviour
{
    public static ItemInjector Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("More than one ItemInjector in the scene");
        Instance = this;
    }

    public void Inject()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var item = transform.GetChild(i).GetComponent<Item>();
            Inventory.Inventory.Instance.AddItem(item);
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
