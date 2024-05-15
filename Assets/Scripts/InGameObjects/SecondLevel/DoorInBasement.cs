using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorInBasement : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private Transform _teleportPosition;
    [SerializeField] private Rigidbody2D _playerRigidbody2D;
    [SerializeField] private Light2D _globalLight;
    [SerializeField] private Light2D _playerVision;

    public void Interact()
    {
        InteractionSoundScript.Instance.openDoorSound.Play();
        _playerRigidbody2D.position = _teleportPosition.position;
        _globalLight.intensity = 1;
        _playerVision.intensity = 0;
    }
}
