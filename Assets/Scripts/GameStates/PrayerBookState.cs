using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PrayerBookState : GameState
{
    [SerializeField] private Canvas prayBookCanvas; 
    public static GameState Instance { get; private set; }
    public static bool IsBlocked;
    private void Awake()
    {
        if (Instance != null)
            Debug.LogWarning("Found more than one state in the scene");
        Instance = this;
    }

    public override void TurnOn()
    {
        prayBookCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CustomInputInitializer.CustomInput.Global.ClosePrayerBook.performed += ClosePrayerBook;
        CustomInputInitializer.CustomInput.Global.Pause.performed += OnPausePressed;
        PrayerBookLearning.Instance?.TryStartLearning();
    }

    public override void TurnOff()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        prayBookCanvas.enabled = false;
        CustomInputInitializer.CustomInput.Global.ClosePrayerBook.performed -= ClosePrayerBook;
        CustomInputInitializer.CustomInput.Global.Pause.performed -= OnPausePressed;
        PrayerBookLearning.Instance?.OnBookClose();
    }

    public void ClosePrayerBook(InputAction.CallbackContext callbackContext)
    {
        if(!IsBlocked) Transite(null);
    }
}
