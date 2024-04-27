using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameStates
{
    public class DefaultState : GameState
    {
        private CustomInput _customInput;
        public static GameState Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null)
                Debug.LogWarning("Found more than one state in the scene");
            Instance = this;
        }

        public override void TurnOn()
        {
            CustomInputInitializer.CustomInput.Player.Enable();
            CustomInputInitializer.CustomInput.Global.OpenBestiary.performed += HandleBestiary;
        }

        public override void TurnOff()
        {
            CustomInputInitializer.CustomInput.Player.Disable();
            CustomInputInitializer.CustomInput.Global.OpenBestiary.performed -= HandleBestiary;
        }

        private void HandleBestiary(InputAction.CallbackContext callbackContext)
        {
            Transite(BestiaryState.Instance);
        }
    }
}