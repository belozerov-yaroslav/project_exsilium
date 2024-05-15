using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    private readonly HashSet<string> _neededKeys = new() { "w", "a", "s", "d" }; 

    private void Start()
    {
        TryStartLearning();
    }
    
    protected override void StartLearning()
    {
        learningHint.SetActive(true);
        CustomInputInitializer.CustomInput.Player.Movement.performed += ListenInput;
    }

    protected override void StopLearning()
    {
        learningHint.SetActive(false);
        CustomInputInitializer.CustomInput.Player.Movement.performed -= ListenInput;
        LearningManager.Instance.StopLearning();
    }

    private void ListenInput(InputAction.CallbackContext callbackContext)
    {
        if (_neededKeys.Contains(callbackContext.control.name))
            _neededKeys.Remove(callbackContext.control.name);
        if (_neededKeys.Count == 2)
        {
            _wasCompleted = true;
            StopLearning();
        }
    }
}
