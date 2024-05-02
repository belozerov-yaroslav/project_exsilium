using Inventory.Items_Classes;
using UnityEngine;

public class ItemInteraction : MonoBehaviour, InteractionAbstraction
{
    public Item item;
    public void Interact()
    {
        Inventory.Inventory.Instance.AddItem(item);
        Destroy(gameObject);
    }
}