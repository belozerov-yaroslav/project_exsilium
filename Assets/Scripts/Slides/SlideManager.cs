using System;
using System.Collections;
using System.Collections.Generic;
using GameStates;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SlideManager : MonoBehaviour
{
    [SerializeField] private Canvas slideCanvas;
    [SerializeField] private Image previousSlide;
    [SerializeField] private Image currentSlide;
    private int _index;
    private List<Slide> _currentSlides;
    public static SlideManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
            Debug.LogWarning("Found more than one slideManager in the scene");
        Instance = this;
    }

    public void ShowSlideGroup(List<Slide> slides)
    {
        CustomInputInitializer.CustomInput.SlideShow.NextSlide.performed += NextSlide;
        slideCanvas.gameObject.SetActive(true);
        GameStateMachine.Instance.StateTransition(SlideShowState.Instance);
        _currentSlides = slides;
        _index = 0;
        previousSlide.color = new Color(0, 0, 0, 1f);
        currentSlide.color = new Color(1, 1, 1, 0f);
        _currentSlides[0].TurnOn();
    }

    private void NextSlide(InputAction.CallbackContext context)
    {
        _index++;
        if (_index >= _currentSlides.Count) EndOfShow();
        else
        {
            _currentSlides[_index - 1].StopAllCoroutines();
            _currentSlides[_index].TurnOn();
        }
    }

    private void EndOfShow()
    {
        CustomInputInitializer.CustomInput.SlideShow.NextSlide.performed -= NextSlide;
        _currentSlides[_index - 1].StopAllCoroutines();
        _currentSlides[_index - 1].TurnOff();
        GameStateMachine.Instance.StateTransition(null);
    }
}