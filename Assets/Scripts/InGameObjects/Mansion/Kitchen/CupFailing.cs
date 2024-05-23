using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupFailing : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (GlobalVariables.CupFall)
            _animator.Play("IdleBroken");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger("Failing");
            GlobalVariables.CupFall = true;
        }
    }
}
