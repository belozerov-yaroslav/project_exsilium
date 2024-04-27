using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameStates
{
    public class BestiaryState : GameState
    {
        [SerializeField] private Bestiary _bestiary; 
        public static GameState Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null)
                Debug.LogWarning("Found more than one state in the scene");
            Instance = this;
        }

        public override void TurnOn()
        {
            Debug.Log("kekw");
            _bestiary.OpenBestiary();
            CustomInputInitializer.CustomInput.Bestiary.Enable();
            CustomInputInitializer.CustomInput.Global.OpenBestiary.performed += CloseBestiary;
        }

        public override void TurnOff()
        {
            _bestiary.CloseBestiary();
            CustomInputInitializer.CustomInput.Bestiary.Disable();
            CustomInputInitializer.CustomInput.Global.OpenBestiary.performed -= CloseBestiary;
        }

        private void CloseBestiary(InputAction.CallbackContext callbackContext)
        {
            Transite(null);
        }
    }
}