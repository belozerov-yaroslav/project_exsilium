using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Script : MonoBehaviour
{
    [SerializeField] private GameObject sound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerInteraction"))
            Destroy(sound);
    }
}
