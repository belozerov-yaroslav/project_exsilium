using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BubbleText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int CoroutineLocker = 0;
    [SerializeField] private float AppearanceTime = 1f;
    [SerializeField] private float StayTime = 1.5f;
    [SerializeField] private float DisappearanceTime = 0.5f;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetTextAlpha(0f);
    }

    private void SetTextAlpha(float value)
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, value);
    }

    private IEnumerator CloseMessage()
    {
        CoroutineLocker += 1;
        var t = CoroutineLocker;
        yield return new WaitForSeconds(StayTime + AppearanceTime);
        if (CoroutineLocker != t) yield break;
        StartCoroutine(ChangeValueSmooth.Change(1f, 0f, SetTextAlpha, DisappearanceTime));
        CoroutineLocker = 0;
    }

    public void ShowMessage(string message)
    {
        _text.text = message;
        _text.enabled = true;
        StartCoroutine(ChangeValueSmooth.Change(0f, 1f, SetTextAlpha, AppearanceTime));
        StartCoroutine(CloseMessage());
    }
}
