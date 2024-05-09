using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BubbleText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int CoroutineLocker = 0;
    public static BubbleText Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.Log("More than one bubble text in the scene");
        Instance = this;
    }

    void Start()
    {
        _text.enabled = false;
    }

    private IEnumerator CloseMessage()
    {
        CoroutineLocker += 1;
        var t = CoroutineLocker;
        yield return new WaitForSeconds(3f);
        if (CoroutineLocker != t) yield break;
        _text.enabled = false;
        CoroutineLocker = 0;
    }

    public void ShowMessage(string message)
    {
        _text.text = message;
        _text.enabled = true;
        StartCoroutine(CloseMessage());
    }
}
