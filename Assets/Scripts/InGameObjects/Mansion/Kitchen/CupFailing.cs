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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger("Failing");
        }
    }
}
