using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerInteraction"))
            _audioSource.mute = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerInteraction"))
            _audioSource.mute = true;
    }
}
