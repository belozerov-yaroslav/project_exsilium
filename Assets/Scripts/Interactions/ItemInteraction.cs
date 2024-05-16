using Inventory.Items_Classes;
using UnityEngine;

public class ItemInteraction : MonoBehaviour, InteractionAbstraction
{
    public Item item;
    public void Interact()
    {
        InteractionSoundScript.Instance.pickingUpSound.Play();
        Inventory.Inventory.Instance.AddItem(item);
        gameObject.SetActive(false);
    }
}