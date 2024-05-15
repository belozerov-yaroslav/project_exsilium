using System;
using System.Collections;
using System.Collections.Generic;
using Inventory.Items_Classes;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemInteractionClass : MonoBehaviour
{
    [SerializeField] public ItemEnum itemEnum;

    public AudioSource itemInteractionSound;

    private void Awake()
    {
        itemInteractionSound = GetComponent<AudioSource>();
    }
}
