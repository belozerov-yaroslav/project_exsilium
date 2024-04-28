using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<Quest> _quests;
    private int _index;
    private Quest _currentQuest;

    public void Awake()
    {
        _currentQuest = _quests[0];
        _currentQuest.QuestCompeted += HandleQuest;
    }

    private void HandleQuest()
    {
        _currentQuest.QuestCompeted -= HandleQuest;
        _currentQuest.FinishQuest();
        _index++;
        if (_index >= _quests.Count) return;
        _currentQuest = _quests[_index];
        _currentQuest.QuestCompeted += HandleQuest;
    }
}
