using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameStates
{
    public class BestiaryState : GameState
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
            Bestiary.Instance.OpenBestiary();
            CustomInputInitializer.CustomInput.Bestiary.Enable();
            CustomInputInitializer.CustomInput.Global.OpenBestiary.performed += CloseBestiary;
            CustomInputInitializer.CustomInput.Global.Pause.performed += OnPausePressed;
            BestiaryOpenLearning.Instance?.OnBestiaryOpen();
            BestiaryNavigationLearning.Instance?.TryStartLearning();
        }

        public override void TurnOff()
        {
            CustomInputInitializer.CustomInput.Global.Pause.performed -= OnPausePressed;
            CustomInputInitializer.CustomInput.Bestiary.Disable();
            CustomInputInitializer.CustomInput.Global.OpenBestiary.performed -= CloseBestiary;
        }

        private void CloseBestiary(InputAction.CallbackContext callbackContext)
        {
            Bestiary.Instance.CloseBestiary();
            BestiaryNavigationLearning.Instance?.StopLearning();
            BestiaryCloseLearning.Instance?.OnBestiaryClose();
            InventoryLearning.Instance?.TryStartLearning();
            Transite(null);
        }
    }
}