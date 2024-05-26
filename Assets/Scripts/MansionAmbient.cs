using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MansionAmbient : MonoBehaviour
{
    private void Start()
    {
        SlideManager.Instance.OnSlideEnd += StartAmbient;
    }

    private void StartAmbient()
    {
        AmbientScript.Instance.AppearAmbient("Level5");
    }
}
