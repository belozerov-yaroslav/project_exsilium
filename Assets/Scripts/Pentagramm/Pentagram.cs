using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pentagram : MonoBehaviour
{
    private Animator pentagramAnimator;
    public Image pentagramImage;
    [SerializeField]private AudioSource chalkSound;
    [SerializeField]private AudioSource starSound;
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
        starSound.Play();
    }

    public void DrawCircle()
    {
       pentagramAnimator.SetTrigger(Circle1);
       chalkSound.Play();
    }

    public void DrawCompleted()
    {
        PentagrammController.Instance.GetQteResult(false);
        PentagrammController.Instance.FinishQte();
        ChalkInteractCompleted?.Invoke();
    }

    public event Action ChalkInteractCompleted;
}
