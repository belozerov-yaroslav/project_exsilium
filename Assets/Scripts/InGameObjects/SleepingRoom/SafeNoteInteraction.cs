using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeNoteInteraction : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private List<Slide> slides;
    public void Interact()
    {
        GlobalVariables.IsSafeNoteRead = true;
        SlideManager.Instance.ShowSlideGroup(slides);
    }
}
