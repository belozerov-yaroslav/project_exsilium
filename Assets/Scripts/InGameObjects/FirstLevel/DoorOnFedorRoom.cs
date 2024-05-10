using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorOnFedorRoom : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private FirstQuest quest;
    private Rigidbody2D playerRigidbody2D;
    [SerializeField] private Transform streetTeleport;
    [SerializeField] private Light2D globalLight2D;
    [SerializeField] private AudioSource doorSound;
    private bool _itemsCollected;
    private void Awake()
    {
        doorSound = GetComponent<AudioSource>();
        quest.QuestCompeted += HandleQuest;
    }

    private void Start()
    {
        playerRigidbody2D = Player.Instance.GetComponent<Rigidbody2D>();
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
            playerRigidbody2D.position = streetTeleport.position;
        }
        else
        {
            BubbleText.Instance.ShowMessage("Мне надо собрать мои вещи");
        }
    }
}
