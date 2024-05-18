using System;
using System.Collections;
using UnityEngine;

public class ChangeValueSmooth
{
    public static IEnumerator Change(float startValue, float endValue, Action<float> valueSetter, float appearanceTime, Func<float, float> curve = null)
    {
        curve ??= AnimationCurves.Linear;
        var time = 0f;
        valueSetter(startValue);
        while (time < appearanceTime)
        {
            time += Time.deltaTime;
            if (startValue < endValue)
                valueSetter(curve(time / appearanceTime));
            else
                valueSetter(curve(startValue - time / appearanceTime));
            yield return null;
        }

        valueSetter(endValue);
    }
}