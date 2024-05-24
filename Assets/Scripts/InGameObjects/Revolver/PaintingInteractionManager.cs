using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaintingInteractionManager : MonoBehaviour
{
    [SerializeField] private OutlineManager _outlineManager;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource woodSound;
    private bool _ifPlayerInTrigger;
    private static readonly int Remove = Animator.StringToHash("Remove");
    private static readonly int Removed = Animator.StringToHash("Removed");

    private void Start()
    {
        if (GlobalVariables.IsPaintingRemoved) animator.SetBool(Removed, true);
        else CustomInputInitializer.CustomInput.Player.Interaction.performed += OnInteractionPerformed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("PlayerInteraction")) return;
        _ifPlayerInTrigger = true;
        if (GlobalVariables.IsSafeNoteRead && !GlobalVariables.IsPaintingRemoved) _outlineManager.TurnOnOutline();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("PlayerInteraction")) return;
        _ifPlayerInTrigger = false;
        _outlineManager.TurnOffOutline();
    }

    private void OnInteractionPerformed(InputAction.CallbackContext obj)
    {
        if (_ifPlayerInTrigger && GlobalVariables.IsSafeNoteRead && !GlobalVariables.IsPaintingRemoved)
            RemovePainting();
    }

    private void RemovePainting()
    {
        InteractionSoundScript.Instance.pickingUpSound.Play();
        woodSound.Play();
        GlobalVariables.IsPaintingRemoved = true;
        animator.SetTrigger(Remove);
    }
}