using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private OutlineManager _outlineManager;
    [SerializeField] private CustomInputInitializer _input;
    [SerializeField] private BoxCollider2D _playerTrigger;
    [SerializeField] private MonoBehaviour _action;
    private bool _ifPlayerInTrigger = false;

    private void Start()
    {
        _input.CustomInput.Global.Interaction.performed += OnInteractionPerformed;
    }

    private void OnDisable()
    {
        _input.CustomInput.Global.Interaction.performed -= OnInteractionPerformed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != _playerTrigger) return;
        _ifPlayerInTrigger = true;
        _outlineManager.TurnOnOutline();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != _playerTrigger) return;
        _ifPlayerInTrigger = false;
        _outlineManager.TurnOffOutline();
    }

    private void OnInteractionPerformed(InputAction.CallbackContext obj)
    {
        if (_ifPlayerInTrigger) (_action as InteractionAbstraction).Interact();
    }
}