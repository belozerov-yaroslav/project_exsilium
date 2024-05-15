using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BestiaryCloseLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    private bool isEnabled;
    public static BestiaryCloseLearning Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two BestiaryCloseLearning in the scene");
        Instance = this;
    }
    
    protected override void StartLearning()
    {
        isEnabled = true;
        learningHint.SetActive(true);
        CustomInputInitializer.CustomInput.Global.OpenBestiary.performed += ListenInput;
        
    }

    protected override void StopLearning()
    {
        isEnabled = false;
        learningHint.SetActive(false);
        LearningManager.Instance.StopLearning();
        CustomInputInitializer.CustomInput.Global.OpenBestiary.performed -= ListenInput;
        InventoryLearning.Instance?.TryStartLearning();
    }

    private void ListenInput(InputAction.CallbackContext callbackContext)
    {
        if (!isEnabled) return;
        _wasCompleted = true;
        StopLearning();
    }
}