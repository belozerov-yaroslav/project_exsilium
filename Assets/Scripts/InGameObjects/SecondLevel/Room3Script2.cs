using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room3Script2 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _fedor2;
    [SerializeField] private Light2D _fedor2Light;
    [SerializeField] private AudioSource _ravingsSounds;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerInteraction") && _fedor2 != null && _fedor2.enabled)
        {
            _ravingsSounds.Stop();
            _fedor2.enabled = false;
            _fedor2Light.enabled = false;
            Destroy(_fedor2);
        }
    }
}
