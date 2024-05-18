using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    public static InteractionLearning Instance { get; private set; }
    private bool isEnabled;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two Interaction learning in the scene");
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

    public void OnInteractionCompleted()
    {
        if (!isEnabled) return;
        _wasCompleted = true;
        LearningManager.Instance.StopLearning();
        StopLearning();
    }
}