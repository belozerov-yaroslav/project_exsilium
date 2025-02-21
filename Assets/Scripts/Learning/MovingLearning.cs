using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    private readonly HashSet<string> _neededKeys = new() { "w", "a", "s", "d" }; 
    private bool isEnabled;

    private void Start()
    {
        TryStartLearning();
    }
    
    public override void StartLearning()
    {
        isEnabled = true;
        learningHint.SetActive(true);
        CustomInputInitializer.CustomInput.Player.Movement.performed += ListenInput;
    }

    public override void StopLearning()
    {
        isEnabled = false;
        learningHint.SetActive(false);
        CustomInputInitializer.CustomInput.Player.Movement.performed -= ListenInput;
    }

    private void ListenInput(InputAction.CallbackContext callbackContext)
    {
        if (!isEnabled) return;
        if (_neededKeys.Contains(callbackContext.control.name))
            _neededKeys.Remove(callbackContext.control.name);
        if (_neededKeys.Count == 2)
        {
            _wasCompleted = true;
            LearningManager.Instance.StopLearning();
            StopLearning();
        }
    }
}
