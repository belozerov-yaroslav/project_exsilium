using System;
using System.Collections;
using System.Collections.Generic;
using GameStates;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private OutlineManager boxOutline;
    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;
    private static readonly int WalkIn = Animator.StringToHash("WalkIn");

    private void Start()
    {
        if (GlobalVariables.Slept3)
        {
            boxOutline.TurnOnOutline();
            GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            DialogueManager.GetInstance().OnDialogueEnd += Handle;
        }
    }

    private void Handle()
    {
        boxOutline.TurnOffOutline();
        DialogueManager.GetInstance().OnDialogueEnd -= Handle;
        Vasil.Animator.SetTrigger(WalkIn);
    }
}