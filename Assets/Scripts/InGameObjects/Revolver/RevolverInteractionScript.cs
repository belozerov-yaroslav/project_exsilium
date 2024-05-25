using UnityEngine;

namespace InGameObjects.Revolver
{
    public class RevolverInteractionScript : MonoBehaviour, IInteraction
    {
        private void Start()
        {
            if (GlobalVariables.IsRevolverCollected) gameObject.SetActive(false);
        }

        public void Interact()
        {
            InteractionSoundScript.Instance.revolverPickingUpSound.Play();
            GlobalVariables.IsRevolverCollected = true;
            Player.BubbleText.ShowMessage("Этот револьвер может пригодиться");
            gameObject.SetActive(false);
        }
    }
}