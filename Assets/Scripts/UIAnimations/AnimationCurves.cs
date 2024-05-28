using System;

public static class AnimationCurves
{
    public static float Linear(float value)
    {
        return value;
    }

    public static float Quadratic(float value)
    {
        return value * value;
    }
    public static float ThirdGrade(float value)
    {
        return (float)Math.Pow(value, 3);
    }

    public static float CameraCurve(float value)
    {
        return (float)(-Math.Pow(-value + 1, 3) + 1);
    }
}