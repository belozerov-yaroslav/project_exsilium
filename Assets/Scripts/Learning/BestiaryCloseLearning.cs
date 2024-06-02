using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;

public class BestiaryCloseLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    private bool isEnabled;
    public static BestiaryCloseLearning Instance { get; private set; }

    public override bool OverrideStack => true;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two BestiaryCloseLearning in the scene");
        Instance = this;
    }
    
    private void OnDestroy()
    {
        Instance = null;
    }
    
    public override void StartLearning()
    {
        isEnabled = true;
        learningHint.SetActive(true);
    }

    public override void StopLearning()
    {
        isEnabled = false;
        learningHint.SetActive(false);
        InventoryLearning.Instance?.TryStartLearning();
    }

    public void OnBestiaryClose()
    {
        _wasCompleted = true;
        if (!isEnabled) return;
        LearningManager.Instance.StopLearning();
        StopLearning();
    }
}