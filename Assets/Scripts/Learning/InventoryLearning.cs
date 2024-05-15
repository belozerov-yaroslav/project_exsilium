using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    public static InventoryLearning Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two InventoryLearning in the scene");
        Instance = this;
    }
    
    protected override void StartLearning()
    {
        learningHint.SetActive(true);
    }

    protected override void StopLearning()
    {
        learningHint.SetActive(false);
        LearningManager.Instance.StopLearning();
        ItemActionLearning.Instance?.TryStartLearning();
    }

    public void OnItemPicked()
    {
        _wasCompleted = true;
        StopLearning();
    }
}