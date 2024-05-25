using System;
using BanishSystem;
using UnityEngine;

public class HandleBanishFinishedBedroom : MonoBehaviour
{
    [SerializeField] private GameObject _babaika;
    private void Start()
    {
        BanishManager.BanishFinished += Handle;
    }

    private void Handle()
    {
        Debug.Log("Изгание в спальне завершено");
        Destroy(_babaika);
        GlobalVariables.MorokBanished = true;
    }

    private void OnDestroy()
    {
        BanishManager.BanishFinished -= Handle;
    }
}