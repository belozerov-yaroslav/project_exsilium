using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class AppearanceScript : MonoBehaviour
{
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]public float timeAppearance = 3f;
    [SerializeField] private float transparencyStep = 0.001f;
    private Color _currentColor;
    private float _startTime;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _currentColor = spriteRenderer.color;
        _startTime = -timeAppearance;
    }
    
    void Update()
    {
        if (_startTime + timeAppearance > Time.time)
        {
            _currentColor = spriteRenderer.color;
            spriteRenderer.color = new Color(_currentColor.r, _currentColor.g,
                _currentColor.b, _currentColor.a + transparencyStep);
                
        }
    }

    public void StartAppear() => _startTime = Time.time;
}
