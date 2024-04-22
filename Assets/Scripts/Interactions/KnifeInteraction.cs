using UnityEngine;

namespace Interactions
{
    public class KnifeInteraction : MonoBehaviour, InteractionAbstraction
    {
        public AudioSource interactionSound;
        public void Interact()
        {
            Inventory.AddItem(GetComponent<Item>());
            interactionSound.Play();
            Debug.Log("На нож нажали");
        }
    }
}
