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
    public void TurnOff(bool revertCamera)
    {
        if (revertCamera)
            CameraMovement.Instance.RevertPosition(0.2f);
        _animator.SetTrigger("TurnOff");
    }

    private void AnimatorEventOff()
    {
        OnTurnOff?.Invoke();
    }
}
