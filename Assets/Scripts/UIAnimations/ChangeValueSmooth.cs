using System;
using System.Collections;
using UnityEngine;

public class ChangeValueSmooth
{
    public static IEnumerator Change(float startValue, float endValue, Action<float> valueSetter, float appearanceTime, Func<float, float> curve = null)
    {
        curve ??= AnimationCurves.Linear;
        var time = 0f;
        var segmentSize = Math.Abs(endValue - startValue);
        valueSetter(startValue);
        while (time < appearanceTime)
        {
            time += Time.deltaTime;
            if (startValue < endValue)
                valueSetter(curve(startValue + segmentSize * time / appearanceTime));
            else
                valueSetter(curve(startValue - segmentSize * time / appearanceTime));
            yield return null;
        }

        valueSetter(endValue);
    }
}