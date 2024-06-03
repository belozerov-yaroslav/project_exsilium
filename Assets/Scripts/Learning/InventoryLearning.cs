using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    public static InventoryLearning Instance { get; private set; }
    private bool isEnabled;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two InventoryLearning in the scene");
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

    public void OnItemPicked()
    {
        _wasCompleted = true;
        if (!isEnabled) return;
        LearningManager.Instance.StopLearning();
        StopLearning();
    }
}