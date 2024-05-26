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
        _animator = PlacedHerbs.GetComponent<Animator>();
        _animator.SetTrigger(ColorHerbs);
        Debug.Log("Изгнание в спальне завершено");
        Destroy(_babaika);
        GlobalVariables.MorokBanished = true;
    }

    private void OnDestroy()
    {
        BanishManager.BanishFinished -= Handle;
    }
}