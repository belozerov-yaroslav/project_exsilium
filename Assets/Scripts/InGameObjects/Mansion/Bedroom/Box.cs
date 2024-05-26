using System;
using System.Collections;
using System.Collections.Generic;
using GameStates;
using UnityEngine;

public class Box : MonoBehaviour
{
    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;
    private static readonly int WalkIn = Animator.StringToHash("WalkIn");

    private void Start()
    {
        if (GlobalVariables.Slept3)
        {
            GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            DialogueManager.GetInstance().OnDialogueEnd += Handle;
        }
    }

    private void Handle()
    {
        DialogueManager.GetInstance().OnDialogueEnd -= Handle;
        Vasil.Animator.SetTrigger(WalkIn);
    }
}