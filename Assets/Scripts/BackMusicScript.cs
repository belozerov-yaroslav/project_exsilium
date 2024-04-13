using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusicScript : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isOn = true;
    private float _lastTimeOn;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _lastTimeOn = -_audioSource.time;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isOn)
        {
            if (Time.time - _lastTimeOn > _audioSource.time)
            {
                _lastTimeOn = Time.time;
                Debug.Log("a");
                _audioSource.Play();
            }
        }
        else 
            _audioSource.Stop();
    }

    public void MusicOn() => _isOn = true;
    public void MusicOff() => _isOn = false;
}
