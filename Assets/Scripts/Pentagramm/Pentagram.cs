using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pentagram : MonoBehaviour
{
    private Animator pentagramAnimator;
    public Image pentagramImage;
    private static readonly int Start1 = Animator.StringToHash("Start");
    private static readonly int Circle1 = Animator.StringToHash("Start Circle");

    void Start()
    {
        pentagramAnimator = GetComponent<Animator>();
        pentagramImage = GetComponent<Image>();
    }

    public void DrawStartState()
    {
        pentagramAnimator.SetTrigger(Start1);
    }

    public void DrawCircle()
    {
       pentagramAnimator.SetTrigger(Circle1); 
    }

    public void DrawCompleted()
    {
        PentagrammController.Instance.GetQteResult(false);
        PentagrammController.Instance.FinishQte();
        ChalkInteractCompleted?.Invoke();
    }

    public event Action ChalkInteractCompleted;
}
