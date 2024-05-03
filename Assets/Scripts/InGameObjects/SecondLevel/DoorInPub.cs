using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorInPub : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private BubbleText _bubbleText;
    [SerializeField] private Transform _teleportPosition;
    [SerializeField] private Rigidbody2D _playerTransform;
    [SerializeField] private Light2D _globalLight;
    public void Interact()
    {
        if (((BoolValue)DialogueManager.GetInstance().GetVariableState("take_keys")).value)
        {
            _playerTransform.position = _teleportPosition.position;
            _globalLight.intensity = 0.3f;
        }
        else
        {
            _bubbleText.ShowMessage("Мне нужно поговорить с Марией");
        }
        
    }
}
