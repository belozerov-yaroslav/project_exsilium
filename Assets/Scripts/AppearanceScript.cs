using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AppearanceScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float timeAppearance; 
    
    private Color _fillColor;
    private Color _startColor;
    private float _startTime;
    void Start()
    {
        _startColor = spriteRenderer.color;
        _fillColor = new Color(_startColor.r, _startColor.g, _startColor.b, 1f);
        StartAppear();
    }

    // Update is called once per frame
    void Update()
    {
        if (_startTime + timeAppearance > Time.time)
        {
            spriteRenderer.color =
                Color.Lerp(spriteRenderer.color, _fillColor, _startTime + timeAppearance - Time.time);
        }
    }

    public void StartAppear()
    {
        _startTime = Time.time;
    }
}
