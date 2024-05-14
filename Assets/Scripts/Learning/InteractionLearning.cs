using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    public static InteractionLearning Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two Interaction learning in the scene");
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
    }

    public void OnInteractionCompleted()
    {
        StopLearning();
    }
}