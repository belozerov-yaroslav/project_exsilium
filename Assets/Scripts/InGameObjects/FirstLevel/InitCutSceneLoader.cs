using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitCutSceneLoader : MonoBehaviour
{
    [SerializeField] private List<Slide> slides;
    void Start()
    {
        SlideManager.Instance.ShowSlideGroup(slides);
    }
}
