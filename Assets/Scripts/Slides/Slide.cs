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
        var c = StartCoroutine(FadeInImage());
    }

    public void TurnOff()
    {
        StartCoroutine(FadeOutImage());
    }

    private IEnumerator FadeInImage()
    {
        currentImage.sprite = image;
        yield return StartCoroutine(ChangeValueSmooth.Change(0f, 1f,
            value => currentImage.color = new Color(1, 1, 1, value), fadeDuration, AnimationCurves.SeventhGrade));
        previousImage.color = new Color(1, 1, 1, 1f);
        previousImage.sprite = image;
        currentImage.color = new Color(1, 1, 1, 0f);
    }

    private IEnumerator FadeOutImage()
    {
        previousImage.sprite = image;
        yield return StartCoroutine(ChangeValueSmooth.Change(1f, 0f,
            value => previousImage.color = new Color(1, 1, 1, value), fadeDuration, AnimationCurves.SeventhGrade));
        currentImage.color = new Color(1, 1, 1, 0f);
    }
}