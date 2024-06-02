using System;
using System.Collections;
using System.Collections.Generic;
using GameStates;
using Ink.Runtime;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private OutlineManager boxOutline;
    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;

    [SerializeField] private Transform _cameraPosition;

    private void Start()
    {
        if (GlobalVariables.Slept3)
        {
            boxOutline.TurnOnOutline();
            GlobalVariables.Slept3 = false;
            GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON, transform.position, Player.Instance.transform.position, false);
            DialogueManager.GetInstance().OnDialogueEnd += Handle;
        }
    }

    private void Handle()
    {
        boxOutline.TurnOffOutline();
        if (((BoolValue)DialogueManager.GetInstance().GetVariableState("banish_ghost")).value)
            InteractionSoundScript.Instance.banishFinishedSound.Play();
        CameraMovement.Instance.MoveToPosition(_cameraPosition.position, 1f);
        DialogueManager.GetInstance().OnDialogueEnd -= Handle;
        StartCoroutine(Vasil.Instance.WalkIn());
    }
}