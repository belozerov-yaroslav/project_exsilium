using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : MonoBehaviour
{
    public Sprite ItemSprite { get; private set; }

    private void Start()
    {
        ItemSprite = GetComponent<SpriteRenderer>().sprite;
    }
}
