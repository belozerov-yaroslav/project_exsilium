using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room3Script3 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _fedor2;
    [SerializeField] private AudioSource _ravingsSounds;
    private bool _wasTriggered;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_wasTriggered && other.CompareTag("PlayerInteraction") && _fedor2 != null && _fedor2.enabled)
        {
            _wasTriggered = true;
            _ravingsSounds.Play();
        }
    }
}
