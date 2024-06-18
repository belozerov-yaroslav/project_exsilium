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
            PauseInterface.Instance.Show();
            Pause.TransitionTo(0.5f);
        }

        public void OnInterfaceShow()
        {
            Time.timeScale = 0;
            CustomInputInitializer.CustomInput.Global.Pause.performed += OnPausePressed;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public override void TurnOff()
        {
            Normal.TransitionTo(0.5f);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _exitConfirmation.CloseConfirmation();
        }
        
        public void OnInterfaceHide()
        {
            Transite(null);
        }

        public void OnUIButtonPressed()
        {
            InteractionSoundScript.Instance.PlayMenuButtonSound();
            ClosePauseMenu();
        }

        private void ClosePauseMenu()
        {
            Time.timeScale = 1;
            PauseInterface.Instance.Hide();
            CustomInputInitializer.CustomInput.Global.Pause.performed -= OnPausePressed;
        }

        private new void OnPausePressed(InputAction.CallbackContext callbackContext)
        {
            if (!LevelLoader.Instance.IsLoad())
            {
                if (_audioSettnigs.Turned) _audioSettnigs.TurnOff();
                else ClosePauseMenu();
            }
        }
    }
}