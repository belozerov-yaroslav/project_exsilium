using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest1 : Quest
{
    [SerializeField] private TestTrigger trigger;


    public void Awake()
    {
        trigger.PlayerEntered += HandleTrigger;
    }

    private void HandleTrigger()
    {
        QuestCompeted?.Invoke();
    }

    public override event Action QuestCompeted;

    public override void FinishQuest()
    {
        Destroy(trigger.gameObject);
    }
}