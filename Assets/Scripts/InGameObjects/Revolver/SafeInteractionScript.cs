using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SafeInteractionScript : MonoBehaviour
{
    [SerializeField] private GameObject revolver;
    [SerializeField] private OutlineManager _outlineManager;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource safeSound;
    [SerializeField] private AudioSource closedSound;
    private static readonly int Opened = Animator.StringToHash("Opened");
    private static readonly int Open = Animator.StringToHash("Open");
    private bool _ifPlayerInTrigger;

    private void Start()
    {
        if (GlobalVariables.IsSafeOpen)
        {
            animator.SetBool(Opened, true);
            if (!GlobalVariables.IsRevolverCollected)
            {
                Debug.Log("Дошли");
                revolver.SetActive(true);
            }
        }
        else CustomInputInitializer.CustomInput.Player.Interaction.performed += OnInteractionPerformed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("PlayerInteraction")) return;
        _ifPlayerInTrigger = true;
        if (!GlobalVariables.IsSafeOpen) _outlineManager.TurnOnOutline();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("PlayerInteraction")) return;
        _ifPlayerInTrigger = false;
        _outlineManager.TurnOffOutline();
    }

    private void OnInteractionPerformed(InputAction.CallbackContext obj)
    {
        if (GlobalVariables.IsPaintingRemoved && !GlobalVariables.IsSafeOpen && _ifPlayerInTrigger)
        {
            if (GlobalVariables.IsKeyCollected) OpenSafe();
            else
            {
                Player.BubbleText.ShowMessage("У меня нет ключа от этого сейфа");
                closedSound.Play();
            }
        }
    }

    private void OpenSafe()
    {
        _outlineManager.TurnOffOutline();
        safeSound.Play();
        animator.SetTrigger(Open);
        GlobalVariables.IsSafeOpen = true;
    }

    public void ActivateRevolver()
    {
        revolver.SetActive(true);
    }
}