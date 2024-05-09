using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorOnFedorRoom : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private FirstQuest quest;
    [SerializeField] private BubbleText bubble;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Transform streetTeleport;
    [SerializeField] private Light2D globalLight2D;
    [SerializeField] private AudioSource doorSound;
    private bool _itemsCollected;
    private void Awake()
    {
        doorSound = GetComponent<AudioSource>();
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
            globalLight2D.intensity = 0.15f;
            doorSound.Play();
            player.position = streetTeleport.position;
        }
        else
        {
            bubble.ShowMessage("Мне надо собрать мои вещи");
        }
    }
}
