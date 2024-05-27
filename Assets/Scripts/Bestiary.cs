using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bestiary : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Canvas _canvas;
    private const float MaxPage = 7.01f;
    private float _page;
    private static readonly int Page = Animator.StringToHash("Page");
    private static readonly int Browsing = Animator.StringToHash("Browsing");
    private static readonly int PrevPage = Animator.StringToHash("prevPage");
    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource browsingSound;

    private void Start()
    {
        CustomInputInitializer.CustomInput.Bestiary.BestiaryNavigation.performed += HandleNavigation;
    }

    private void HandleNavigation(InputAction.CallbackContext obj)
    {
        var value = obj.ReadValue<float>() + _page;
        if (!(value > -0.01) || !(value < MaxPage)) return;
        animator.SetFloat(PrevPage, _page + 0.01f);
        _page = value;
        animator.SetFloat(Page, _page);
        animator.SetBool(Browsing, true);
        browsingSound.Play();
    }
    
    public void OpenBestiary()
    {
        _canvas.enabled = true;
        openSound.Play();
    }

    public void CancelBrowsing()
    {
        animator.SetBool(Browsing, false);
    }

    public void CloseBestiary()
    {
        _canvas.enabled = false;
        closeSound.Play();
    }
}