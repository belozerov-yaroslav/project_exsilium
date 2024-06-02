using System;
using System.Collections;
using System.Collections.Generic;
using BanishSystem;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TargetCircle : MonoBehaviour
{
    [SerializeField] public float timeAim;
    public Canvas PrayGameCanvas;
    
    public GameObject backGroundPanel;
    public AudioSource praySound;
    
    private WayPoint _waypointScript;
    private Image _backgroundImage;
    private AppearanceScript _appearanceScript;
    private SpriteRenderer _spriteRenderer;
    
    private bool _isStarted;
    private Vector2 _circleCenter;
    private float _circleRadius;
    private float _timeLeft;
    
    private int _score;
    private int _maxScore;
    public float scorePercent;
    public PrayEnum pray;
 
    private Color _currentColor;
    
    [SerializeField] public float transparencyStep;
    
    private Color _defaultBackColor;
    private Color _defaultCircleColor;
    private Vector2 _startPosition;
    void Start()
    {
        _waypointScript = GetComponent<WayPoint>();
        _backgroundImage = backGroundPanel.GetComponent<Image>();
        _appearanceScript = GetComponent<AppearanceScript>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _currentColor = _backgroundImage.color;
        _maxScore = (int)timeAim * 50;
        
        _circleRadius = transform.localScale.x / 2;
        _circleCenter = transform.position;
 
        
        _defaultBackColor = _currentColor;
        _defaultCircleColor = _spriteRenderer.color;
        _startPosition = transform.localPosition;
    }

    private void FixedUpdate()
    {
        _circleCenter = transform.position;
        if(!_isStarted || (_timeLeft + _appearanceScript.timeAppearance - Time.time > 0)) return;
        if( _isStarted && !_waypointScript.IsStarted)
            StartMove();
        if (_timeLeft + timeAim + _appearanceScript.timeAppearance - Time.time > 0)
            CheckAccuracy();
        else
            FinishAim();
    }
    
    public void StartAim()
    {
        _isStarted = true;
        _timeLeft = Time.time;
        _appearanceScript.StartAppear();
    }

    public void StartMove()
    {
        praySound.Play();
        _waypointScript.IsStarted = true;
    }


    public delegate void Result(float percent,PrayEnum pray);
    public static event Result OnFinished;
    
    public void FinishAim()
    {
        praySound.Stop();
        _isStarted = false;
        _waypointScript.FinishWay();
        _backgroundImage.color = _defaultBackColor;
        _currentColor = _defaultBackColor;
        _spriteRenderer.color = _defaultCircleColor;
        transform.localPosition = _startPosition;
        PrayerBookState.IsBlocked = false;
        GameStateMachine.Instance.StateTransition(null);
        PrayGameCanvas.enabled = false;
        scorePercent = (float)_score / _maxScore * 100f;
        OnFinished?.Invoke(scorePercent,pray);
    }

    private void CheckAccuracy()
    {
        var centerPosition = Camera.main.WorldToScreenPoint(_circleCenter);
        var distance = (centerPosition - Input.mousePosition).magnitude;
        if (distance <= _circleRadius)
        {
            _score++;
            GetBright();
        }
        else
        {
            GetBlackOut();
        }
        
    }


    private void GetBright()
    {
        _currentColor = new Color(_currentColor.r, _currentColor.g, _currentColor.b, 
            Math.Max(_currentColor.a - 3 * transparencyStep, 0f));
        _backgroundImage.color = _currentColor;
    }
    
    private void GetBlackOut()
    {
        _currentColor = new Color(_currentColor.r, _currentColor.g, _currentColor.b, 
            Math.Min(_currentColor.a + transparencyStep,1f));
        _backgroundImage.color = _currentColor;
        
    }
}
