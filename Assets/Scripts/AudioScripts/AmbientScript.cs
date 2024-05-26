using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class AmbientScript : MonoBehaviour
{
    public static AmbientScript Instance { get; private set; }
    public float smoothTime;
    
    [SerializeField] private AudioSource spbAmbient;
    [SerializeField] private AudioSource basementAmbient;
    [SerializeField] private AudioSource mansionAmbient;
    
    private Dictionary<string, AudioSource> _ambientForLevels = new Dictionary<string, AudioSource>();
    
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
    private void Start()
    {
        _ambientForLevels["Level 1"] = spbAmbient;
        _ambientForLevels["Level2"] = basementAmbient;
        _ambientForLevels["Level3"] = spbAmbient;
        _ambientForLevels["Level5"] = mansionAmbient;
    }

    public void AppearAmbient(string levelName)
    {
        if(!_ambientForLevels.ContainsKey(levelName))
            return;
        var currentMusic = _ambientForLevels[levelName];
        var currentVolume = currentMusic.volume; 
        currentMusic.volume = 0f;
        currentMusic.Play();
        StartCoroutine(ChangeValueSmooth.Change(0f, currentVolume,
            value => currentMusic.volume = value
            , smoothTime, AnimationCurves.ThirdGrade));
    }

    public void StopAmbient()
    {
        var currentMusic = _ambientForLevels[SceneManager.GetActiveScene().name];
        var currentVolume = currentMusic.volume;
        StartCoroutine(ChangeValueSmooth.Change(currentVolume, 0f,
            value => { 
                currentMusic.volume = value;
                if (value == 0)
                {
                    currentMusic.Stop();
                    currentMusic.volume = currentVolume;
                } 
            }, smoothTime, AnimationCurves.ThirdGrade));
    }
}
