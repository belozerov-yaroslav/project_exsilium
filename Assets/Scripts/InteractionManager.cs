using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private OutlineManager _outlineManager;
    [SerializeField] private MonoBehaviour _action;
    private bool _ifPlayerInTrigger;

    private void Start()
    {
        CustomInputInitializer.CustomInput.Player.Interaction.performed += OnInteractionPerformed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("PlayerInteraction")) return;
        _ifPlayerInTrigger = true;
        InteractionLearning.Instance?.TryStartLearning();
        _outlineManager.TurnOnOutline();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("PlayerInteraction")) return;
        _ifPlayerInTrigger = false;
        _outlineManager.TurnOffOutline();
    }

    private void OnInteractionPerformed(InputAction.CallbackContext obj)
    {
        if (_ifPlayerInTrigger)
        {
            InteractionLearning.Instance?.OnInteractionCompleted();
            (_action as InteractionAbstraction).Interact();
        }
    }
}