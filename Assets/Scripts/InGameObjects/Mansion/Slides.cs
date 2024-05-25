using System;
using System.Collections.Generic;
using UnityEngine;

public class Slides : MonoBehaviour
{
    [SerializeField] private List<Slide> _slides;

    public void ShowSlides()
    {
        SlideManager.Instance.ShowSlideGroup(_slides);
    }
}