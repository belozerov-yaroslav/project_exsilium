using Inventory.Items_Classes;
using UnityEngine;

public class ItemInteraction : MonoBehaviour, IInteraction
{
    public Item item;
    public void Interact()
    {
        InteractionSoundScript.Instance.pickingUpSound.Play();
        Inventory.Inventory.Instance.AddItem(item);
        gameObject.SetActive(false);
    }
}