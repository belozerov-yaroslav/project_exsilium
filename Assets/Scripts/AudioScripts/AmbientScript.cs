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
    
    private string LastLevelName { get; set; } 
    
    private Dictionary<string, AudioSource> _ambientForLevels = new Dictionary<string, AudioSource>();
    private Dictionary<string, float> _ambientVolumes = new Dictionary<string, float>();

    private List<string> _ambientOnLoad = new List<string>();
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
    private void Start()
    {
        _ambientForLevels["Level 1"] = spbAmbient;
        _ambientVolumes["Level 1"] = spbAmbient.volume;
        _ambientForLevels["Level2"] = basementAmbient;
        _ambientVolumes["Level2"] = basementAmbient.volume ;
        _ambientForLevels["Level3"] = spbAmbient;
        _ambientVolumes["Level3"] = spbAmbient.volume ;
        _ambientForLevels["Level5"] = mansionAmbient;
        _ambientVolumes["Level5"] = mansionAmbient.volume ;
        _ambientOnLoad.Add("Level3");
    }

    public void StartOnLoad(string levelName)
    {
        StartCoroutine(nameof(StopAmbient));
        if (_ambientOnLoad.Contains(levelName))
        {
            AppearAmbient(levelName);
        }
        else
        {
            StopAmbient();
        }
    }

    public void AppearAmbient(string levelName)
    {
        if(!_ambientForLevels.ContainsKey(levelName))
            return;
        var currentMusic = _ambientForLevels[levelName];
        var currentVolume = _ambientVolumes[levelName]; 
        currentMusic.volume = 0f;
        currentMusic.Play();
        StartCoroutine(ChangeValueSmooth.Change(0f, currentVolume,
            value => currentMusic.volume = value
            , smoothTime, AnimationCurves.ThirdGrade));
        LastLevelName = levelName;
    }

    public void StopAmbient()
    {
        if(LastLevelName == null || !_ambientForLevels.ContainsKey(LastLevelName)) return;
        var currentMusic = _ambientForLevels[LastLevelName];
        var currentVolume = _ambientVolumes[LastLevelName];
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
