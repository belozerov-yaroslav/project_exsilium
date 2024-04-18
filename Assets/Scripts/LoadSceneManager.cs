using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private string sampleSceneName;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // put this object in dont destroy
    }

    public void LoadSampleScene()
    {
        SceneManager.LoadScene(sampleSceneName);
    }
}
