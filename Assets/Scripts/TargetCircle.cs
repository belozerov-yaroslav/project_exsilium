using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TargetCircle : MonoBehaviour
{
    public GameObject parentCanvas;
    public float timeAim;

    public GameObject backGroundPanel;
    public float maxDistanceOffset;
    
    private WayPoint _waypointScript;
    private SpriteRenderer _spriteRenderer;
    private Image _backgroundImage;
    
    private bool _isStarted;
    private Vector2 _circleCenter;
    private float _circleRadius;
    
    private int _score;
    private int _maxScore;
 
    private Color _currentColor;
    
    private float _startTime;
    [SerializeField] public float timeDelay;
    [SerializeField] public float transparencyStep;
    private Color _circleFullColor;
    private float _timeLeft;
    [SerializeField] public float correctnessCoefficient ;
    
    //Дефолтные значения для нового запуска
    private Color _defaultColor;
    private Color _circleStartColor;
    private Vector2 _startPosition;
    void Start()
    {
        _waypointScript = GetComponent<WayPoint>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _backgroundImage = backGroundPanel.GetComponent<Image>();
        _currentColor = _backgroundImage.color;
        _maxScore = (int)timeAim * 50;
        
        _circleRadius = transform.localScale.x / 2;
        _circleCenter = transform.position;
 
        
        _defaultColor = new Color(0,0,0,0f);
        _circleStartColor = _spriteRenderer.color;
        
        _circleFullColor = new Color(_circleStartColor.r,_circleStartColor.g, _circleStartColor.b, 1f);
    }

    private void FixedUpdate()
    {
        _circleCenter = transform.position;
        if (_isStarted)
        {
            if (timeAim + _startTime - Time.time < 0)
            {
                FinishAim();
            }
            CheckAccuracy();
        }
    }
    public void StartAim()
    {
        _startTime = Time.time;
        _isStarted = true;
        parentCanvas.SetActive(true);
    }
    
    public void FinishAim()
    {
        if(_score > _maxScore*correctnessCoefficient)
            Debug.Log("набрал нужное количество");
        else
        {
            Debug.Log("не набрал нужное количество");
        }

        _backgroundImage.color = _defaultColor;
        _currentColor = _defaultColor;
        _isStarted = false;
        _waypointScript.StopWay();
        parentCanvas.SetActive(false);
    }

    private void CheckAccuracy()
    {
        var centerPosition = Camera.main!.WorldToScreenPoint(_circleCenter);
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
            Math.Max(_currentColor.a -3*transparencyStep,0f));
        _backgroundImage.color = _currentColor;
    }
    
    private void GetBlackOut()
    {
        _currentColor = new Color(_currentColor.r, _currentColor.g, _currentColor.b, 
            Math.Min(_currentColor.a + transparencyStep,1f));
        _backgroundImage.color = _currentColor;
        
    }
}
