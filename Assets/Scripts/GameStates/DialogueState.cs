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
        }

        public override void TurnOff()
        {
            CustomInputInitializer.CustomInput.Dialogue.Disable();
        }
    }
}