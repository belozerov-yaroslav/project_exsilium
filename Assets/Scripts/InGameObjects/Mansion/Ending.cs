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
    [SerializeField] private Image _escImage;
    [SerializeField] private Slides greenSlides;
    [SerializeField] private Slides orangeSlides;
    [SerializeField] private Slides redSlides;
    [SerializeField] private MusicManager mm;
    private float _delay = 1f;

    private AudioSource revolverShot;
    
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two Ending in the scene");
        Instance = this;
        _canvas.enabled = false;
        revolverShot = GetComponent<AudioSource>();
    }

    private IEnumerator Revolver()
    {
        yield return new WaitForSeconds(_delay);
        revolverShot.Play();
    }

    private IEnumerator Fade(Slides slides)
    {
        _canvas.enabled = true;
        yield return new WaitForSeconds(_delay);
        _blackImage.color = new Color(_blackImage.color.r, _blackImage.color.g, _blackImage.color.b, 1f);
        yield return new WaitForSeconds(1.5f);
        slides.ShowSlides();
        StartCoroutine(ChangeValueSmooth.Change(0f, 1f,
            value => _escImage.color = new Color(_escImage.color.r, _escImage.color.g, _escImage.color.b, value),
            1f));
    }

    public void GreenEnding()
    {
        StartCoroutine(Fade(greenSlides));
        MusicManager.Instance.ChangeLevelMusic("green end"); 
    }

    public void OrangeEnding()
    {
        StartCoroutine(Fade(orangeSlides));
        MusicManager.Instance.ChangeLevelMusic("orange end");
        StartCoroutine(Revolver());
    }

    public void RedEnding()
    {
        StartCoroutine(Fade(redSlides));
        MusicManager.Instance.ChangeLevelMusic("red end"); 
        StartCoroutine(Revolver());
    }
}