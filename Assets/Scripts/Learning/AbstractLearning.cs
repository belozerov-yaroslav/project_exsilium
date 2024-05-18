using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class AbstractLearning : MonoBehaviour
{
    protected bool _wasCompleted = false;
    public virtual bool OverrideStack => false;
    public void TryStartLearning()
    {
        if (!_wasCompleted && LearningManager.Instance.TryStartLearning(this))
            StartLearning();
    }

    public abstract void StartLearning();
    public abstract void StopLearning();
}