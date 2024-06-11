using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ChairFailing : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    private static readonly int Failed = Animator.StringToHash("Failed");
    private static readonly int Failing = Animator.StringToHash("Failing");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if (GlobalVariables.ChairFailed)
            _animator.SetTrigger(Failed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && GlobalVariables.Slept && !GlobalVariables.ChertBanished)
        {
            _animator.SetTrigger(Failing);
            GlobalVariables.ChairFailed = true;
        }
    }

    private void PlaySound()
    {
        _audioSource.Play();
    }
}