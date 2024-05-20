using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BestiaryOpenLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    private bool isEnabled;

    public static BestiaryOpenLearning Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Find another BestiaryOpenLearning in the scene");
        Instance = this;
    }

    private void Start()
    {
        TryStartLearning();
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

    public void OnBestiaryOpen()
    {
        if (!isEnabled) return;
        _wasCompleted = true;
        LearningManager.Instance.StopLearning();
        StopLearning();
    }
}
