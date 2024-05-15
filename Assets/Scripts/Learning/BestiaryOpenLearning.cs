using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BestiaryLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;

    private void Start()
    {
        TryStartLearning();
    }
    
    protected override void StartLearning()
    {
        learningHint.SetActive(true);
        CustomInputInitializer.CustomInput.Global.OpenBestiary.performed += ListenInput;
    }

    protected override void StopLearning()
    {
        learningHint.SetActive(false);
        CustomInputInitializer.CustomInput.Global.OpenBestiary.performed -= ListenInput;
        LearningManager.Instance.StopLearning();
    }

    private void ListenInput(InputAction.CallbackContext callbackContext)
    {
        _wasCompleted = true;
        StopLearning();
    }
}
