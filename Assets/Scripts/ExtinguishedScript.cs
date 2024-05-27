using System;
using System.Collections;
using System.Collections.Generic;
using BanishSystem;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ExtinguishedScript : MonoBehaviour
{
    public static GameObject PlacedCandle;
    private static readonly int Extinguished = Animator.StringToHash("extinguished");
    private Animator _animator;
    private Light2D _candleLight;
    
    private void Start()
    {
        BanishManager.BanishFinished += Extinguish;
    }

    private void OnDestroy()
    {
        BanishManager.BanishFinished -= Extinguish;
    }

    public void Extinguish()
    {
        _animator = PlacedCandle.GetComponent<Animator>();
        _candleLight = PlacedCandle.GetComponent<Light2D>();
        _candleLight.intensity = 0f;
        _animator.SetTrigger(Extinguished);
    }
}
