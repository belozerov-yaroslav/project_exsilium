using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest2 : Quest
{
    [SerializeField] private Collider2D trigger;
    [SerializeField] private Collider2D playerTrigger;

    public override void UpdateQuest()
    {
        if (!trigger.IsTouching(playerTrigger)) return;
        IsFinished = true;
        Finish();
    }

    private void Finish()
    {
        Debug.Log("Квест завершён ");
    }
    
    public override bool IsFinished { get; protected set; }
}