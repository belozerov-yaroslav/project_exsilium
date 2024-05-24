using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = Unity.Mathematics.Random;

[RequireComponent(typeof(Image))]
public class HeatEffect : MonoBehaviour
{
    private Image heatImage;
    [SerializeField] private float _maxAlpha;
    [SerializeField] private float _minAlpha;
    [SerializeField] private float _minStep;
    [SerializeField] private float _speed;

    private void Start()
    {
        heatImage = GetComponent<Image>();
        _maxAlpha /= 255;
        _minAlpha /= 255;
        _minStep /= 255;
        StartCoroutine(RunHeatEffect());
    }

    private void AlphaSetter(float value)
    {
        heatImage.color = new Color(heatImage.color.r, heatImage.color.g, heatImage.color.b, value);
    }

    private IEnumerator RunHeatEffect()
    {
        while (true)
        {
            var random = new Random(52);
            var currentValue = heatImage.color.a;
            var newValue = random.NextFloat(_minAlpha, _maxAlpha);
            while (Math.Abs(newValue - currentValue) < _minStep)
                newValue = random.NextFloat(_minAlpha, _maxAlpha);
            yield return ChangeValueSmooth.Change(currentValue, newValue, AlphaSetter,
                _speed * Math.Abs(newValue - currentValue) / (_maxAlpha - _minAlpha));
        }
    }
}