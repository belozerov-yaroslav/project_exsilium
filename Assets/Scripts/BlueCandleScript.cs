using System;
using System.Collections;
using System.Collections.Generic;
using BanishSystem;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlueCandleScript : MonoBehaviour
{
    public static GameObject PlacedCandle;
    private Animator _animator;
    private static readonly int BlueFlame = Animator.StringToHash("Blue flame");

    private void Start()
    {
        BanishManager.BanishFinished += ChangeColor;
    }

    public void ChangeColor()
    {
        _animator = PlacedCandle.GetComponent<Animator>();
        _animator.SetTrigger(BlueFlame);
    }

    private void OnDestroy()
    {
        BanishManager.BanishFinished -= ChangeColor;
    }
}
