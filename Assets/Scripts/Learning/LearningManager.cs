using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningManager : MonoBehaviour
{
    public static LearningManager Instance { get; private set; }
    private AbstractLearning _currentLearning;
    [SerializeField] private Canvas _learningCanvas;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two LearningManagers in the scene");
        Instance = this;
    }

    public bool TryStartLearning(AbstractLearning learning)
    {
        if (_currentLearning is not null) return false;
        _currentLearning = learning;
        _learningCanvas.enabled = true;
        return true;
    }

    public void StopLearning()
    {
        _currentLearning = null;
        _learningCanvas.enabled = false;
    }
}
