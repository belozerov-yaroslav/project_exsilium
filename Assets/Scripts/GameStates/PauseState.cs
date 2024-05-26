using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace GameStates
{
    
    public class PauseState : GameState
    {
        public static GameState Instance { get; private set; }
        [SerializeField] private Canvas _pauseCanvas;
        [SerializeField] private AudioSettings _audioSettnigs;
        [SerializeField] private NewGameConfirmation _exitConfirmation;

        public AudioMixerSnapshot Normal;
        public AudioMixerSnapshot Pause;
        
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
            Pause.TransitionTo(0.5f);
            CustomInputInitializer.CustomInput.Global.Pause.performed += OnPausePressed;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public override void TurnOff()
        {
            Time.timeScale = 1;
            Normal.TransitionTo(0.5f);
            _pauseCanvas.enabled = false;
            _audioSettnigs.TurnOff();
            _exitConfirmation.CloseConfirmation();
            CustomInputInitializer.CustomInput.Global.Pause.performed -= OnPausePressed;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnUIButtonPressed()
        {
            InteractionSoundScript.Instance.PlayMenuButtonSound();
            Transite(null);
        }

        private new void OnPausePressed(InputAction.CallbackContext callbackContext)
        {
            if (!LevelLoader.Instance.IsLoad())
                Transite(null);
        }
    }
}