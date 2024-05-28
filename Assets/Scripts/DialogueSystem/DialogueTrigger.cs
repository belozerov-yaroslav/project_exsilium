using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour, IInteraction
{
    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;

    public void Interact()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON, transform.position, Player.Instance.transform.position);
        }
    }
}