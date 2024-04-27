using Inventory.Items_Classes;
using UnityEngine;

namespace Interactions
{
    public class KnifeInteraction : MonoBehaviour, InteractionAbstraction
    {
        public Inventory.Inventory playerInventory;
        public AudioSource interactionSound;
        [SerializeField] private BubbleText _bubbleText;
        public void Interact()
        {
            playerInventory.AddItem(GetComponent<Item>());
            interactionSound.Play();
            Debug.Log("На нож нажали");
            _bubbleText?.ShowMessage("На нож нажали");
        }
    }
}
