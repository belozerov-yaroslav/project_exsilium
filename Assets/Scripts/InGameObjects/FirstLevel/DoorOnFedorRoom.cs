using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOnFedorRoom : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private FirstQuest quest;
    [SerializeField] private BubbleText bubble;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Transform streetTeleport;
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
            player.position = streetTeleport.position;
        }
        else
        {
            bubble.ShowMessage("Мне надо собрать мои вещи");
        }
    }
}
