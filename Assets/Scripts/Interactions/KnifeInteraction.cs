using Inventory.Items_Classes;
using UnityEngine;

namespace Interactions
{
    public class KnifeInteraction : MonoBehaviour, InteractionAbstraction
    {
        public Inventory.Inventory playerInventory;
        public AudioSource interactionSound;
        public void Interact()
        {
            playerInventory.AddItem(GetComponent<Item>());
            interactionSound.Play();
            Debug.Log("На нож нажали");
        }
    }
}
