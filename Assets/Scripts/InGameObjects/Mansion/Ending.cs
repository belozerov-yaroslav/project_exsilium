using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public static Ending Instance { get; private set; }
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _blackImage;
    [SerializeField] private Slides greenSlides;
    [SerializeField] private Slides orangeSlides;
    [SerializeField] private Slides redSlides;
    [SerializeField] private MusicManager mm;

    private AudioSource revolverShot;
    
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two Ending in the scene");
        Instance = this;
        _canvas.enabled = false;
        revolverShot = GetComponent<AudioSource>();
    }

    private IEnumerator Fade(Slides slides)
    {
        _canvas.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _blackImage.color = new Color(_blackImage.color.r, _blackImage.color.g, _blackImage.color.b, 1f);
        yield return new WaitForSeconds(1.5f);
        slides.ShowSlides();
    }

    public void GreenEnding()
    {
        StartCoroutine(Fade(greenSlides));
        MusicManager.Instance.ChangeLevelMusic("green end"); 
        Debug.Log("Green");
    }

    public void OrangeEnding()
    {
        StartCoroutine(Fade(orangeSlides));
        MusicManager.Instance.ChangeLevelMusic("orange end"); 
        revolverShot.Play();
        Debug.Log("Orange");
    }

    public void RedEnding()
    {
        StartCoroutine(Fade(redSlides));
        MusicManager.Instance.ChangeLevelMusic("red end"); 
        revolverShot.Play();
        Debug.Log("Red");
    }
}