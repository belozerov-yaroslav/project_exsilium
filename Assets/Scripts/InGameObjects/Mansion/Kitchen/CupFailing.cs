using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CupFailing : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
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

    private void PlayBrokeSound()
    {
        _audioSource.Play();
    }
}
