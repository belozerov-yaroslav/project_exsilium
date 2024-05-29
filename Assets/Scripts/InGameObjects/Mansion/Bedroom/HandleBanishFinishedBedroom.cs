using System;
using BanishSystem;
using UnityEngine;

public class HandleBanishFinishedBedroom : MonoBehaviour
{
    public static GameObject PlacedHerbs;
    private Animator _animator;
    [SerializeField] private GameObject _babaika;
    private static readonly int ColorHerbs = Animator.StringToHash("Color Herbs");

    private void Start()
    {
        BanishManager.BanishFinished += Handle;
    }

    private void Handle()
    {
        InteractionSoundScript.Instance.banishFinishedSound.Play();
        _animator = PlacedHerbs.GetComponent<Animator>();
        _animator.SetTrigger(ColorHerbs);
        Destroy(_babaika);
        GlobalVariables.MorokBanished = true;
        if (GlobalVariables.MertvyakBanished && GlobalVariables.ChertBanished)
            Player.BubbleText.ShowMessage("Уже поздно, мне надо идти спать");
    }

    private void OnDestroy()
    {
        BanishManager.BanishFinished -= Handle;
    }
}