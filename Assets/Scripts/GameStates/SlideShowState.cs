using UnityEngine;

namespace GameStates
{
    public class SlideShowState : GameState
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
            CustomInputInitializer.CustomInput.SlideShow.Enable();
        }

        public override void TurnOff()
        {
            CustomInputInitializer.CustomInput.SlideShow.Disable();
        }
    }
}