using Inventory.Items_Classes;
using UnityEngine;

namespace Interactions
{
    public class KnifeInteraction : MonoBehaviour, InteractionAbstraction
    {
        public Inventory.Inventory playerInventory;
        public void Interact()
        {
            playerInventory.AddItem(GetComponent<Item>());
            gameObject.SetActive(false);
        }
    }
}
