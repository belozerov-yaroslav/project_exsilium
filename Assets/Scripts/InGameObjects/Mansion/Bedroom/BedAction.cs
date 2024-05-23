using UnityEngine;

public class BedAction : InteractionAbstraction
{
    [SerializeField] private BedroomDoor _bedroomDoor;
    public void Interact()
    {
        _bedroomDoor.Locked = true;
        throw new System.NotImplementedException();
    }
}