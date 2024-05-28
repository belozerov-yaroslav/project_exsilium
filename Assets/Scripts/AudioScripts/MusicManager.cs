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
    [SerializeField] private AudioSource level5Music;
    [SerializeField] private AudioSource level6Music;
    [SerializeField] private AudioSource level7Music;
    [SerializeField] private AudioSource level9Music;
    
    [SerializeField] public AudioSource greenMusic;
    [SerializeField] public AudioSource orangeMusic;
    [SerializeField] public AudioSource redMusic;
    
    private Dictionary<string, AudioSource> _musicForLevels = new Dictionary<string, AudioSource>();
    private Dictionary<string, float> _volumesDict = new Dictionary<string, float>();
    
    private string LastName { get; set; }
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _musicForLevels["MainMenu"] = menuMusic;
        _volumesDict["MainMenu"] = menuMusic.volume;
        _musicForLevels["Level 1"] = level1Music;
        var level1Volume = level1Music.volume;
        _volumesDict["Level 1"] = level1Volume;
        _musicForLevels["Level2"] = level2Music;
        _volumesDict["Level2"] = level2Music.volume;
        _musicForLevels["Level3"] = level1Music;
        _volumesDict["Level3"] = level1Volume;
        _musicForLevels["Level4"] = level1Music;
        _volumesDict["Level4"] = level1Volume;
        _musicForLevels["Level5"] = level5Music;
        _volumesDict["Level5"] = level5Music.volume;
        _musicForLevels["Level6"] = level6Music;
        var level6Volume = level6Music.volume;
        _volumesDict["Level6"] = level6Volume;
        _musicForLevels["Level7"] = level7Music;
        _volumesDict["Level7"] = level7Music.volume;
        _musicForLevels["Level8"] = level6Music;
        _volumesDict["Level8"] = level6Volume;
        _musicForLevels["Level9"] = level9Music;
        _volumesDict["Level9"] = level9Music.volume;
        
        _musicForLevels["green end"] = greenMusic;
        _volumesDict["green end"] = greenMusic.volume;
        _musicForLevels["orange end"] = orangeMusic;
        _volumesDict["orange end"] = orangeMusic.volume;
        _musicForLevels["red end"] = redMusic;
        _volumesDict["red end"] = redMusic.volume;
        AppearLevelMusic();
    }

    public void ChangeLevelMusic(string nextLevel)
    {
        StopAllCoroutines();
        var previousMusic = _musicForLevels[LastName];
        var prevVolume = _volumesDict[LastName];
        var currentMusic = _musicForLevels[nextLevel];
        var currentVolume = _volumesDict[nextLevel];
        if(previousMusic == currentMusic)
            return;
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
        LastName = nextLevel;
    }

    private void AppearLevelMusic()
    {
        var levelName = SceneManager.GetActiveScene().name;
        StopAllCoroutines();
        var currentMusic = _musicForLevels[levelName];
        var currentVolume = _volumesDict[levelName];
        currentMusic.volume = 0f;
        currentMusic.Play();
        StartCoroutine(ChangeValueSmooth.Change(0f, currentVolume,
            value => currentMusic.volume = value
            , smoothTime, AnimationCurves.ThirdGrade));
        LastName = levelName;
    }
}
