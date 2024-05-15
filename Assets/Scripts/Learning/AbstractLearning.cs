using UnityEngine;

public abstract class AbstractLearning : MonoBehaviour
{
    protected bool _wasCompleted = false;
    public void TryStartLearning()
    {
        if (!_wasCompleted && LearningManager.Instance.TryStartLearning(this))
            StartLearning();
    }

    protected abstract void StartLearning();
    protected abstract void StopLearning();
}