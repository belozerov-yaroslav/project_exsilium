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
}