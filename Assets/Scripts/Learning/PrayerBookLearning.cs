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

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two PrayerBookLearning in the scene");
        Instance = this;
    }
    
    protected override void StartLearning()
    {
        learningHint.SetActive(true);
        isEnabled = true;
    }

    protected override void StopLearning()
    {
        isEnabled = false;
        learningHint.SetActive(false);
        LearningManager.Instance.StopLearning();
    }

    public void OnBookClose()
    {
        if (!isEnabled) return;
        _wasCompleted = true;
        StopLearning();
    }
}