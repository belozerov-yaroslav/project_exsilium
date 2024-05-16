using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace GameStates
{
    public class PauseState : GameState
    {
        public static GameState Instance { get; private set; }
        [SerializeField] private Canvas _pauseCanvas;
        [SerializeField] private AudioSettings _audioSettnigs;

        private void Awake()
        {
            if (Instance != null)
                Debug.LogWarning("Found more than one state in the scene");
            Instance = this;
        }

        public override void TurnOn()
        {
            _pauseCanvas.enabled = true;
            Time.timeScale = 0;
            CustomInputInitializer.CustomInput.Global.Pause.performed += OnPausePressed;
        }

        public override void TurnOff()
        {
            Time.timeScale = 1;
            _pauseCanvas.enabled = false;
            _audioSettnigs.TurnOff();
            CustomInputInitializer.CustomInput.Global.Pause.performed -= OnPausePressed;
        }

        public void OnUIButtonPressed()
        {
            Transite(null);
        }

        private new void OnPausePressed(InputAction.CallbackContext callbackContext)
        {
            Transite(null);
        }
    }
}