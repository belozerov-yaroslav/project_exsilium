using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestMarkerManager : MonoBehaviour
{
    [SerializeField] private float transparency = 1f;
    [SerializeField] private Canvas canvas;
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] private CanvasGroup group;


    public static QuestMarkerManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance.canvas.worldCamera = Camera.main;
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            Instance.canvas.worldCamera = Camera.main;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetCurrentMarker(string message, bool save=true)
    {
        if (save) GlobalVariables.QuestMarker = message;
        StartCoroutine(FadeMarker(message));
    }

    private IEnumerator FadeMarker(string message)
    {
        yield return StartCoroutine(ChangeValueSmooth.Change(group.alpha, 0, value => group.alpha = value,
            1f));
        text.text = message;
        yield return StartCoroutine(ChangeValueSmooth.Change(0, transparency, value => group.alpha = value,
            1f));
    }
}