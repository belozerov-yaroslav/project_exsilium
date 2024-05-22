using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    public float smoothTime;
    
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private AudioSource level1Music;
    [SerializeField] private AudioSource level2Music;
    [SerializeField] private AudioSource level3Music;
    private Dictionary<string, AudioSource> _musicForLevels = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _musicForLevels["MainMenu"] = menuMusic;
        _musicForLevels["Level 1"] = level1Music;
        _musicForLevels["Level2"] = level2Music;
        _musicForLevels["Level3"] = level1Music;
        AppearLevelMusic();
    }

    public void ChangeLevelMusic(string nextLevel)
    {
        var previousMusic = _musicForLevels[SceneManager.GetActiveScene().name];
        var prevVolume = previousMusic.volume;
        var currentMusic = _musicForLevels[nextLevel];
        var currentVolume = currentMusic.volume; 
        currentMusic.volume = 0f;
        currentMusic.Play();
        StartCoroutine(ChangeValueSmooth.Change(0f, currentVolume,
            value => currentMusic.volume = value
            , smoothTime, AnimationCurves.ThirdGrade));
        StartCoroutine(ChangeValueSmooth.Change(previousMusic.volume, 0f,
            value =>
            {
                previousMusic.volume = value;
                if (value == 0)
                {
                    previousMusic.Stop();
                    previousMusic.volume = prevVolume;
                }
            }, smoothTime, AnimationCurves.ThirdGrade));
    }

    private void AppearLevelMusic()
    {
        var currentMusic = _musicForLevels[SceneManager.GetActiveScene().name];
        var currentVolume = currentMusic.volume; 
        currentMusic.volume = 0f;
        currentMusic.Play();
        StartCoroutine(ChangeValueSmooth.Change(0f, currentVolume,
            value => currentMusic.volume = value
            , smoothTime, AnimationCurves.ThirdGrade));
    }


}
