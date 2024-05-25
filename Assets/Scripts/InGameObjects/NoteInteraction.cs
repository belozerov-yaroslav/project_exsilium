using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteraction : MonoBehaviour, IInteraction
{
    [SerializeField] private List<Slide> slides;
    public void Interact()
    {
        SlideManager.Instance.ShowSlideGroup(slides);
    }
}
