using System;
using GameStates;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(Animator))]
public class PauseInterface : MonoBehaviour
{
    public static PauseInterface Instance { get; private set; }
    private static readonly int Appear = Animator.StringToHash("Appear");
    private static readonly int Disappear = Animator.StringToHash("Disappear");

    private Animator _animator;
    private Canvas _canvas;

    private void Start()
    {
        if (Instance != null)
            Debug.LogError("Two PauseInterface in the scene");
        Instance = this;

        _canvas = GetComponent<Canvas>();
        _animator = GetComponent<Animator>();
    }

    public void Show()
    {
        _canvas.enabled = true;
        _animator.SetTrigger(Appear);
    }

    private void OnAppearAnimationEnd() // used in the animator event
    {
        ((PauseState)PauseState.Instance).OnInterfaceShow();
    }
    
    public void Hide()
    {
        _animator.SetTrigger(Disappear);
    }
    
    private void OnDisappearAnimationEnd()  // used in the animator event
    {
        ((PauseState)PauseState.Instance).OnInterfaceHide();
        _canvas.enabled = false;
    }
}