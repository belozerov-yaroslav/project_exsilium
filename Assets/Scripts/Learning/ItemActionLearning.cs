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

    public override bool OverrideStack => true;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two ItemActionLearning in the scene");
        Instance = this;
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
    }

    public void OnItemAction()
    {
        if (!isEnabled) return;
        _wasCompleted = true;
        LearningManager.Instance.StopLearning();
        StopLearning();
    }
}