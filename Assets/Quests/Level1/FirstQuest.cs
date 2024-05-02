using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : Quest
{
    public void Start()
    {
        Inventory.Inventory.Instance.InventoryFilled += HandleAction;
    }

    public override event Action QuestCompeted;

    private void HandleAction()
    {
        QuestCompeted?.Invoke();
    }

    public override void FinishQuest()
    {
    }
}