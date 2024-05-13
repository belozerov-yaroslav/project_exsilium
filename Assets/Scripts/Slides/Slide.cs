using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour
{
    [SerializeField] private Sprite image;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private Image currentImage;
    [SerializeField] private Image previousImage;

    public void TurnOn()
    {
        StartCoroutine(FadeInImage(fadeDuration));
    }

    private IEnumerator FadeInImage(float duration)
    {
        currentImage.color = new Color(1, 1, 1, 0f);
        currentImage.sprite = image;
        var time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            currentImage.color = new Color(1, 1, 1, time / duration);
            yield return null;
        }
        
        previousImage.sprite = image;
        currentImage.color = new Color(1, 1, 1, 0f);
    }
}