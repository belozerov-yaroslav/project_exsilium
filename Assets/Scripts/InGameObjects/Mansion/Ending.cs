using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public static Ending Instance { get; private set; }
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _blackImage;
    [SerializeField] private Slides greenSlides;
    [SerializeField] private Slides orangeSlides;
    [SerializeField] private Slides redSlides;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two Ending in the scene");
        Instance = this;
        _canvas.enabled = false;
    }

    private IEnumerator Fade(Slides slides)
    {
        _canvas.enabled = true;
        yield return StartCoroutine(ChangeValueSmooth.Change(0f, 1f,
            value => _blackImage.color = new Color(_blackImage.color.r, _blackImage.color.g, _blackImage.color.b,
                value), 0.2f));
        yield return new WaitForSeconds(0.5f);
        slides.ShowSlides();
    }

    public void GreenEnding()
    {
        StartCoroutine(Fade(greenSlides));
        Debug.Log("Green");
    }

    public void OrangeEnding()
    {
        StartCoroutine(Fade(orangeSlides));
        Debug.Log("Orange");
    }

    public void RedEnding()
    {
        StartCoroutine(Fade(redSlides));
        Debug.Log("Red");
    }
}