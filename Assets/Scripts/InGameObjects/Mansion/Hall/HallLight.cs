using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HallLight : MonoBehaviour
{
    [SerializeField] private Light2D _globalLight;
    [SerializeField] private List<float> LightIntensity = new()
    {
        0.2f,
        1f,
        0.6f,
        0.2f
    };
    private void Start()
    {
        var c = 0;
        if (GlobalVariables.MorokBanished)
            c += 1;
        if (GlobalVariables.ChertBanished)
            c += 1;
        if (GlobalVariables.MertvyakBanished)
            c += 1;
        _globalLight.intensity = LightIntensity[c];
    }
}