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
    [SerializeField] private Image instructionImage;
    [SerializeField] private float instructionTransparency = 0.6f;
    [SerializeField] private float instructionDelay = 2;
    [SerializeField] private float appearanceTime = 1;
    private int _index;
    private List<Slide> _currentSlides;
    public static SlideManager Instance { get; private set; }
    public event Action OnSlideEnd;


    private void Awake()
    {
        if (Instance != null)
            Debug.LogWarning("Found more than one slideManager in the scene");
        Instance = this;
    }

    public void ShowSlideGroup(List<Slide> slides)
    {
        CustomInputInitializer.CustomInput.SlideShow.NextSlide.performed += NextSlide;
        CustomInputInitializer.CustomInput.SlideShow.NextSlide.performed += TurnOffInstruction;
        slideCanvas.gameObject.SetActive(true);
        GameStateMachine.Instance.StateTransition(SlideShowState.Instance);
        _currentSlides = slides;
        _index = 0;
        previousSlide.color = new Color(0, 0, 0, 1f);
        currentSlide.color = new Color(1, 1, 1, 0f);
        TurnOnInstruction();
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
        OnSlideEnd?.Invoke();
    }

    private void TurnOnInstruction()
    {
        StartCoroutine(FadeInInstructionWithDelay());
    }

    private void TurnOffInstruction(InputAction.CallbackContext context)
    {
        CustomInputInitializer.CustomInput.SlideShow.NextSlide.performed -= TurnOffInstruction;
        StopAllCoroutines();
        StartCoroutine(FadeOutInstruction());
    }

    private IEnumerator FadeInInstructionWithDelay()
    {
        yield return new WaitForSeconds(instructionDelay);
        yield return StartCoroutine(ChangeValueSmooth.Change(instructionImage.color.a, instructionTransparency,
            value => instructionImage.color = new Color(1, 1, 1, value), appearanceTime));
    }


    private IEnumerator FadeOutInstruction()
    {
        yield return StartCoroutine(ChangeValueSmooth.Change(instructionImage.color.a, 0,
            value => instructionImage.color = new Color(1, 1, 1, value), appearanceTime));
    }
}