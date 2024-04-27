using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameStates
{
    public class DefaultState : GameState
    {
        public override event Action<GameState> OnTransition;
        private CustomInput _customInput;
        
        public override void TurnOn()
        {
            CustomInputInitializer.CustomInput.Player.Enable();
            CustomInputInitializer.CustomInput.Global.OpenBestiary.performed += 
                _ => { Transite(BestiaryState.Instance); };
        }
        public override void TurnOff()
        {
            CustomInputInitializer.CustomInput.Player.Disable();
        }
    }
}