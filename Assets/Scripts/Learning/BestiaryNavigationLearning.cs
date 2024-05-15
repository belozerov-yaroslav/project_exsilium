using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BestiaryNavigationLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    public static BestiaryNavigationLearning Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two BestiaryNavigationLearning in the scene!");
        Instance = this;
    }

    protected override void StartLearning()
    {
        learningHint.SetActive(true);
        CustomInputInitializer.CustomInput.Bestiary.BestiaryNavigation.performed += OnBestiaryInput;
    }

    protected override void StopLearning()
    {
        learningHint.SetActive(false);
        CustomInputInitializer.CustomInput.Bestiary.BestiaryNavigation.performed -= OnBestiaryInput;
        LearningManager.Instance.StopLearning();
    }

    private void OnBestiaryInput(InputAction.CallbackContext callbackContext)
    {
        _wasCompleted = true;
        StopLearning();
    }
}
