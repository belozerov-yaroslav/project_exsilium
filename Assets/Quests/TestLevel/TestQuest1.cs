using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest1 : Quest
{
    [SerializeField] private Collider2D trigger;
    [SerializeField] private Collider2D playerTrigger;

    public override void UpdateQuest()
    {
        if (!trigger.IsTouching(playerTrigger)) return;
        IsFinished = true;
    }
    public override bool IsFinished { get; protected set; }
}
