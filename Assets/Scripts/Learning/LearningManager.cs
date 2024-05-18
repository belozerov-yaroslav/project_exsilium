using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningManager : MonoBehaviour
{
    public static LearningManager Instance { get; private set; }
    private Stack<AbstractLearning> _currentLearningStack = new();

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two LearningManagers in the scene");
        Instance = this;
    }

    public bool TryStartLearning(AbstractLearning learning)
    {
        if (_currentLearningStack.Count != 0 && !learning.OverrideStack) return false;
        if (_currentLearningStack.Count != 0)
            _currentLearningStack.Peek().StopLearning();
        _currentLearningStack.Push(learning);
        return true;
    }

    public void StopLearning()
    {
        _currentLearningStack.Pop();
        if (_currentLearningStack.Count != 0)
            _currentLearningStack.Peek().StartLearning();
    }
}
