using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Script : MonoBehaviour
{
    [SerializeField] private GameObject shadow;
    private AudioSource _whisperSound;

    private void Start()
    {
        _whisperSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerInteraction")  && shadow != null)
        {
            Destroy(shadow);
            _whisperSound.Play();
        }
            
    }
}
