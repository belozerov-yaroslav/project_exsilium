using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BackMusicScript : MonoBehaviour
{
    [FormerlySerializedAs("Audio Source")] public AudioSource audioSource;
    private bool _isOn = true;
    private float _lastTimeOn;
    private void Awake()
    {
        _lastTimeOn = -audioSource.clip.length;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isOn)
        {
            if (Time.time - _lastTimeOn > audioSource.clip.length)
            {
                _lastTimeOn = Time.time;
                audioSource.Play();
            }
        }
        else 
            audioSource.Stop();
    }

    public void MusicOn() => _isOn = true;
    public void MusicOff() => _isOn = false;
}
