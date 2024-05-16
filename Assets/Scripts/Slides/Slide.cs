using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour
{
    [SerializeField] private Sprite image;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private Image currentImage;
    [SerializeField] private Image previousImage;

    public void TurnOn()
    {
        StartCoroutine(FadeInImage());
    }
    public void TurnOff()
    {
        StartCoroutine(FadeOutImage());
    }

    private IEnumerator FadeInImage()
    {
        currentImage.color = new Color(1, 1, 1, 0f);
        currentImage.sprite = image;
        var time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            currentImage.color = new Color(1, 1, 1, time / fadeDuration);
            yield return null;
        }
        previousImage.color = new Color(1, 1, 1, 1f);
        previousImage.sprite = image;
        currentImage.color = new Color(1, 1, 1, 0f);
    }
    private IEnumerator FadeOutImage()
    {
        previousImage.sprite = image;
        previousImage.color = new Color(1, 1, 1, 1f);
        var time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            previousImage.color = new Color(1, 1, 1, 1 - time / fadeDuration);
            yield return null;
        }
        
        previousImage.color = new Color(1, 1, 1, 0f);
        currentImage.color = new Color(1, 1, 1, 0f);
    }
}