using UnityEngine;

namespace Interactions
{
    public class KnifeInteraction : MonoBehaviour, InteractionAbstraction
    {
        public Inventory playerInventory;
        public AudioSource interactionSound;
        public void Interact()
        {
            playerInventory.AddItem(GetComponent<Item>());
            interactionSound.Play();
            Debug.Log("На нож нажали");
        }
    }
}
