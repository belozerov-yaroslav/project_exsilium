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
        CameraMovement.Instance.MoveToPosition(_cameraPosition.position, 1f);
        DialogueManager.GetInstance().OnDialogueEnd -= Handle;
        Vasil.Animator.SetTrigger(WalkIn);
    }
}