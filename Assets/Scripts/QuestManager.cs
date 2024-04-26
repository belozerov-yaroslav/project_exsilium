using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<IQuest> _quests;
    private int _index;
    private IQuest _currentQuest;

    public void Awake()
    {
        _currentQuest = _quests[0];
    }

    public void FixedUpdate()
    {
        _currentQuest.Update();
        if (!_currentQuest.IsFinished) return;
        _index++;
        if (_index < _quests.Count) _currentQuest = _quests[_index];
    }
}
