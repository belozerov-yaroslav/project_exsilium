using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrayerBookLearning : AbstractLearning
{
    [SerializeField] private GameObject learningHint;
    public static PrayerBookLearning Instance { get; private set; }
    private bool isEnabled;
    public override bool OverrideStack => true;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two PrayerBookLearning in the scene");
        Instance = this;
    }
    
    private void OnDestroy()
    {
        Instance = null;
    }
    
    public override void StartLearning()
    {
        learningHint.SetActive(true);
        isEnabled = true;
    }

    public override void StopLearning()
    {
        isEnabled = false;
        learningHint.SetActive(false);
    }

    public void OnBookClose()
    {
        if (!isEnabled) return;
        _wasCompleted = true;
        LearningManager.Instance.StopLearning();
        StopLearning();
    }
}