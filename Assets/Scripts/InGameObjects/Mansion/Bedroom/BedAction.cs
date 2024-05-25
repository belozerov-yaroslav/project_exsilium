using UnityEngine;

public class BedAction : MonoBehaviour, IInteraction
{
    [SerializeField] private BedroomDoor _bedroomDoor;
    public void Interact()
    {
        GlobalVariables.Slept = true;
        GlobalVariables.NotFirstMansion = true;
        FirstVisit.Instance.StopWorking();
    }
}