using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorInPub : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private Transform _teleportPosition;
    [SerializeField] private Rigidbody2D _playerTransform;
    [SerializeField] private Light2D _globalLight;
    [SerializeField] private Light2D _playerVision;
    public void Interact()
    {
        if (((BoolValue)DialogueManager.GetInstance().GetVariableState("take_keys")).value)
        {
            if (Inventory.Inventory.Instance.IsFullInventory())
            {
                _playerTransform.position = _teleportPosition.position;
                _globalLight.intensity = 0f;
                _playerVision.intensity = 0.5f;
                InteractionSoundScript.Instance.openDoorSound.Play();
            }
            else Player.BubbleText.ShowMessage("Там мне понадобятся мои вещи");
        }
        else
        {
            if (!InteractionSoundScript.Instance.closedDoorSound.isPlaying)
                InteractionSoundScript.Instance.closedDoorSound.Play();
            Player.BubbleText.ShowMessage("У меня нет ключей от этой двери");
        }
        
    }
}
