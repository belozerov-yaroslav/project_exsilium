using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PentagrammController : MonoBehaviour
{
    public static PentagrammController Instance { get; private set; }

    [SerializeField] private Canvas pentagramCanvas;
    [SerializeField] public Pentagram pentagram;
    [SerializeField] private QTEButtons qteButtons;
    [SerializeField] private Image backPanel;
    [SerializeField] private GameObject startButton;

    [SerializeField] private float timeAppear;

    private float _startTime;
    private bool _isSuccess;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AppearInterface()
    {
        PentagramLearning.Instance.CheckLearning();
        _startTime = Time.time;
        pentagramCanvas.enabled = true;
        SmoothAppearance(backPanel);
        SmoothAppearance(pentagram.pentagramImage);
        pentagram.DrawStartState();
        startButton.SetActive(true);
    }

    public void StartQte()
    {
        if (_startTime + timeAppear > Time.time)
            return;
        startButton.SetActive(false);
        pentagram.DrawCircle();
        CustomInputInitializer.CustomInput.Global.QTE.performed += OnQtePressed;
        qteButtons.SetButtons();
    }

    private void SmoothAppearance(Graphic image)
    {
        var defaultColor = image.color;
        StartCoroutine(ChangeValueSmooth.Change(0f, 1f,
            value => { image.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, value); }, 0.5f,
            AnimationCurves.Quadratic));
    }

    public void OnQtePressed(InputAction.CallbackContext callbackContext)
    {
        if (qteButtons.CheckButton(callbackContext.control.name))
        {
            qteButtons.NextButton();
        }
        else
        {
            qteButtons.WrongLetter();
        }
    }

    public event Action<bool> QteFinished;

    public void FinishQte()
    {
        GlobalVariables.IsPentagramLearned = true;
        qteButtons.ResetQte();
        pentagramCanvas.enabled = false;
        _isSuccess = false;
    }

    public void GetQteResult(bool isSuccess)
    {
        if (_isSuccess)
            return;
        _isSuccess = isSuccess;
        QteFinished?.Invoke(_isSuccess);
    }
}