using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BestiaryLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    private bool isEnabled;

    private void Start()
    {
        TryStartLearning();
    }
    
    public override void StartLearning()
    {
        isEnabled = true;
        learningHint.SetActive(true);
        CustomInputInitializer.CustomInput.Global.OpenBestiary.performed += ListenInput;
    }

    public override void StopLearning()
    {
        isEnabled = false;
        learningHint.SetActive(false);
        CustomInputInitializer.CustomInput.Global.OpenBestiary.performed -= ListenInput;
        BestiaryNavigationLearning.Instance?.TryStartLearning();
    }

    private void ListenInput(InputAction.CallbackContext callbackContext)
    {
        if (!isEnabled) return;
        _wasCompleted = true;
        LearningManager.Instance.StopLearning();
        StopLearning();
    }
}
