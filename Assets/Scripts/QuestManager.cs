using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<Quest> _quests;
    private int _index;
    private Quest _currentQuest;
    private bool _finished;

    public void Awake()
    {
        if (_finished) return;
        _currentQuest = _quests[0];
        _currentQuest.QuestCompeted += HandleQuest;
    }

    private void HandleQuest()
    {
        if (_finished) return;
        _currentQuest.QuestCompeted -= HandleQuest;
        _currentQuest.FinishQuest();
        _index++;
        if (_index >= _quests.Count) _finished = true;
        else
        {
            _currentQuest = _quests[_index];
            _currentQuest.QuestCompeted += HandleQuest;
        }
    }
}
