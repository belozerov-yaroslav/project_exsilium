using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePanelAnimation : MonoBehaviour
{
    private Animator _animator;
    public event Action OnTurnOff;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TurnOn()
    {
        _animator.SetTrigger("TurnOn");
    }
    public void TurnOff()
    {
        _animator.SetTrigger("TurnOff");
    }

    private void AnimatorEventOff()
    {
        OnTurnOff?.Invoke();
    }
}
