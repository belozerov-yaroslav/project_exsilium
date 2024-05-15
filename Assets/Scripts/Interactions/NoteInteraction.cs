using GameStates;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Interactions
{
    public class NoteInteraction : MonoBehaviour, InteractionAbstraction
    {
        [SerializeField] private Canvas noteCanvas;
        [SerializeField] private AudioSource openSound;
        [SerializeField] private AudioSource closeSound;
        
        public void Interact()
        {
            openSound.Play();
            noteCanvas.gameObject.SetActive(true);
            GameStateMachine.Instance.StateTransition(NoteState.Instance);
            CustomInputInitializer.CustomInput.Note.Close.performed += Close;
        }

        private void Close(InputAction.CallbackContext callbackContext)
        {
            CustomInputInitializer.CustomInput.Note.Close.performed -= Close;
            closeSound.Play();
            noteCanvas.gameObject.SetActive(false);
            GameStateMachine.Instance.StateTransition(null);
        }
    }
}