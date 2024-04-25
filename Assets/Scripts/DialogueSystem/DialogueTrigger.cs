using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;
    [SerializeField] private CustomInputInitializer _input;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Start()
    {
        _input.CustomInput.Player.Interaction.performed += OnInteraction;
    }

    private void OnInteraction(InputAction.CallbackContext callback)
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}