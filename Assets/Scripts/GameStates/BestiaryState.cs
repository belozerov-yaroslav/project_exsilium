using System;

namespace GameStates
{
    public class BestiaryState : GameState
    {
        public override event Action<GameState> OnTransition;
        
        public override void TurnOn()
        {
            CustomInputInitializer.CustomInput.Bestiary.Enable();
            CustomInputInitializer.CustomInput.Global.OpenBestiary.performed += 
                _ => { Transite(null); };
        }

        public override void TurnOff()
        {
            CustomInputInitializer.CustomInput.Bestiary.Disable();
        }
    }
}