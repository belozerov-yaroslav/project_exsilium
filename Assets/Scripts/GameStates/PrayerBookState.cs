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
        CustomInputInitializer.CustomInput.Global.ClosePrayerBook.performed += ClosePrayerBook;
        PrayerBookLearning.Instance?.TryStartLearning();
        CustomInputInitializer.CustomInput.Global.Pause.performed += OnPausePressed;
    }

    public override void TurnOff()
    {
        prayBookCanvas.enabled = false;
        CustomInputInitializer.CustomInput.Global.ClosePrayerBook.performed -= ClosePrayerBook;
        PrayerBookLearning.Instance?.OnBookClose();
        CustomInputInitializer.CustomInput.Global.Pause.performed -= OnPausePressed;
    }

    public void ClosePrayerBook(InputAction.CallbackContext callbackContext)
    {
        if(!IsBlocked) Transite(null);
    }
}
