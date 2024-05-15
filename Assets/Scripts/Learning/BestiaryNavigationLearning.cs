using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BestiaryNavigationLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    public static BestiaryNavigationLearning Instance { get; private set; }
    private bool isEnabled;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two BestiaryNavigationLearning in the scene!");
        Instance = this;
    }

    protected override void StartLearning()
    {
        isEnabled = true;
        learningHint.SetActive(true);
        CustomInputInitializer.CustomInput.Bestiary.BestiaryNavigation.performed += OnBestiaryInput;
    }

    protected override void StopLearning()
    {
        isEnabled = false;
        learningHint.SetActive(false);
        CustomInputInitializer.CustomInput.Bestiary.BestiaryNavigation.performed -= OnBestiaryInput;
        LearningManager.Instance.StopLearning();
        BestiaryCloseLearning.Instance?.TryStartLearning();
    }

    private void OnBestiaryInput(InputAction.CallbackContext callbackContext)
    {
        if (!isEnabled) return;
        _wasCompleted = true;
        StopLearning();
    }
}
