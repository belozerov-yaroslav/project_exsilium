using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemActionLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    public static ItemActionLearning Instance { get; private set; }
    private bool isEnabled;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two ItemActionLearning in the scene");
        Instance = this;
    }
    
    protected override void StartLearning()
    {
        isEnabled = true;
        learningHint.SetActive(true);
        CustomInputInitializer.CustomInput.Player.ItemIteraction.performed += OnAction;
    }

    protected override void StopLearning()
    {
        isEnabled = false;
        CustomInputInitializer.CustomInput.Player.ItemIteraction.performed -= OnAction;
        learningHint.SetActive(false);
        LearningManager.Instance.StopLearning();
    }

    public void OnAction(InputAction.CallbackContext callbackContext)
    {
        if (!isEnabled) return;
        _wasCompleted = true;
        StopLearning();
    }
}