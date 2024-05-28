using System;
using UnityEngine;


[RequireComponent(typeof(PeriodicSound))]
public class WhisperOff : MonoBehaviour
{
    private PeriodicSound _whisper;
    private void Start()
    {
        _whisper = GetComponent<PeriodicSound>();
        if (!GlobalVariables.Slept)
        {
            _whisper.StopSounds();
            SlideManager.Instance.OnSlideEnd += Handle;
        }
    }

    private void OnDestroy()
    {
        SlideManager.Instance.OnSlideEnd -= Handle;
    }

    private void Handle()
    {
        if (GlobalVariables.Slept)
            _whisper.StartCoroutine(_whisper.StartSounds());
    }
}