using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room3Script : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _fedor2;
    [SerializeField] private Light2D _fedor2Light;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerInteraction") && _fedor2 != null)
        {
            _fedor2.enabled = true;
            _fedor2Light.enabled = true;
        }
    }
}
