using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bestiary : MonoBehaviour
{
    [SerializeField] private CustomInputInitializer _input;
    private bool _isOpen;

    private void Start()
    {
        _input.CustomInput.Global.OpenBestiary.performed += HandleAction;
    }

    private void HandleAction(InputAction.CallbackContext value)
    {
        if (_isOpen) CloseBestiary();
        else OpenBestiary();
    }

    private void OpenBestiary()
    {
        Debug.Log("lol )))");
        _isOpen = true;
        _input.CustomInput.Global.BestiaryNavigation.Enable();
        _input.CustomInput.Player.Disable();
    }

    private void CloseBestiary()
    {
        _isOpen = false;
        _input.CustomInput.Global.BestiaryNavigation.Disable();
        _input.CustomInput.Player.Enable();
    }
}
