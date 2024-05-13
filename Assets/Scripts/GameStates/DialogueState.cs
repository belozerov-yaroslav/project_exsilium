using UnityEngine;

namespace GameStates
{
    public class DialogueState : GameState
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
            CustomInputInitializer.CustomInput.Dialogue.Enable();
            CustomInputInitializer.CustomInput.Global.Pause.performed += OnPausePressed;
        }

        public override void TurnOff()
        {
            CustomInputInitializer.CustomInput.Global.Pause.performed -= OnPausePressed;
            CustomInputInitializer.CustomInput.Dialogue.Disable();
        }
    }
}