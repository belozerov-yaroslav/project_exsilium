using UnityEngine;

public class BedAction : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private Slides _slildes; 
    public void Interact()
    {
        if (GlobalVariables.Slept)
            return;
        _slildes.ShowSlides();
        GlobalVariables.Slept = true;
        GlobalVariables.NotFirstMansion = true;
        FirstVisit.Instance.StopWorking();
    }
}