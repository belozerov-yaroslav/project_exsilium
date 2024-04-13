using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private BackMusicScript _backMusic;

    private void Start()
    {
        _backMusic = GetComponent<BackMusicScript>();
    }
    
    void Update()
    {
        _backMusic.MusicOff();
    }
}
