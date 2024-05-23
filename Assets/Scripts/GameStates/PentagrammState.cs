using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PentagrammState : GameState
{
    public static GameState Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
            Debug.LogWarning("Found more than one state in the scene");
        Instance = this;
    }

    public override void TurnOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PentagrammController.Instance.AppearInterface();
        CustomInputInitializer.CustomInput.Global.Pause.performed += OnPausePressed;
    }

    public override void TurnOff()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CustomInputInitializer.CustomInput.Global.Pause.performed -= OnPausePressed;
    }
    
}
