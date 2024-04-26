using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bestiary : MonoBehaviour
{
    [SerializeField] private CustomInputInitializer _input;
    [SerializeField] private Animator animator;
    [SerializeField] private Canvas _canvas;
    private bool _isOpen;
    private const float MaxPage = 2.01f;
    private float _page;
    private static readonly int Page = Animator.StringToHash("Page");
    private static readonly int Browsed = Animator.StringToHash("Browsed");
    private static readonly int PrevPage = Animator.StringToHash("prevPage");
    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource browsingSound;

    private void Start()
    {
        _input.CustomInput.Global.BestiaryNavigation.Disable();
        _input.CustomInput.Global.OpenBestiary.performed += HandleAction;
        _input.CustomInput.Global.BestiaryNavigation.performed += HandleNavigation;
    }

    private void HandleNavigation(InputAction.CallbackContext obj)
    {
        var value = obj.ReadValue<float>() + _page;
        if (!(value > -0.01) || !(value < MaxPage)) return;
        animator.SetFloat(PrevPage, _page + 0.01f);
        _page = value;
        animator.SetFloat(Page, _page);
        animator.SetTrigger(Browsed);
        browsingSound.Play();
    }

    private void HandleAction(InputAction.CallbackContext value)
    {
        if (_isOpen) CloseBestiary();
        else OpenBestiary();
    }

    private void OpenBestiary()
    {
        _isOpen = true;
        _input.CustomInput.Global.BestiaryNavigation.Enable();
        _input.CustomInput.Player.Disable();
        _canvas.enabled = true;
        openSound.Play();
    }

    private void CloseBestiary()
    {
        _isOpen = false;
        _input.CustomInput.Global.BestiaryNavigation.Disable();
        _input.CustomInput.Player.Enable();
        _canvas.enabled = false;
        closeSound.Play();
    }
}