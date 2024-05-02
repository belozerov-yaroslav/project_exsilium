using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOnFedorRoom : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private FirstQuest quest;
    [SerializeField] private BubbleText bubble;
    private bool _itemsCollected;
    private void Awake()
    {
        quest.QuestCompeted += HandleQuest;
    }

    private void HandleQuest()
    {
        _itemsCollected = true;
        quest.QuestCompeted -= HandleQuest;
    }

    public void Interact()
    {
        if (_itemsCollected)
        {
            Debug.Log("Типа вышел на улицу");
        }
        else
        {
            bubble.ShowMessage("Мне надо собрать мои вещи");
        }
    }
}
