using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{
    public AudioSource footstepSounds;
    public float minTimeBetweenFootsteps = 0.3f; 
    public float maxTimeBetweenFootsteps = 0.6f;

    private bool isWalking = false;
    private float timeSinceLastFootstep;

    private void Awake()
    {
    }

    private void Update()
    {
        if (isWalking)
        {
            if (Time.time - footstepSounds.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
            {
                footstepSounds.Play();
                timeSinceLastFootstep = Time.time;
            }
        }
        else
            footstepSounds.Stop();
    }
    
    public void StartWalking() => isWalking = true;
    public void StopWalking() => isWalking = false;
    
}
