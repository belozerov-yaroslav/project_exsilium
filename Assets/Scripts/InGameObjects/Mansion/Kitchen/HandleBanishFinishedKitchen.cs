using System;
using BanishSystem;
using UnityEngine;

public class HandleBanishFinishedKitchen : MonoBehaviour
{
    [SerializeField] private GameObject _babaika;
    private void Start()
    {
        BanishManager.BanishFinished += Handle;
    }

    private void Handle()
    {
        Debug.Log("Изгнание в кухне завершено");
        GlobalVariables.ChertBanished = true;
        Destroy(_babaika);
    }

    private void OnDestroy()
    {
        BanishManager.BanishFinished -= Handle;
    }
}