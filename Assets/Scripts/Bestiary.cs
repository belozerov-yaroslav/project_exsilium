using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bestiary : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TextMeshProUGUI _pageCountText;
    private const float MaxPage = 7.01f;
    private float _page;
    private static readonly int Page = Animator.StringToHash("Page");
    private static readonly int Browsing = Animator.StringToHash("Browsing");
    private static readonly int PrevPage = Animator.StringToHash("prevPage");
    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource browsingSound;
    public static Bestiary Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two Bestiary in the scene");
        Instance = this;
    }

    private void Start()
    {
        _pageCountText.text = "1";
        CustomInputInitializer.CustomInput.Bestiary.BestiaryNavigation.performed += HandleNavigation;
    }

    private void HandleNavigation(InputAction.CallbackContext obj)
    {
        var value = obj.ReadValue<float>() + _page;
        if (!(value > -0.01) || !(value < MaxPage)) return;
        animator.SetFloat(PrevPage, _page + 0.01f);
        _page = value;
        _pageCountText.text = ((int)Math.Round(_page + 1)).ToString();
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