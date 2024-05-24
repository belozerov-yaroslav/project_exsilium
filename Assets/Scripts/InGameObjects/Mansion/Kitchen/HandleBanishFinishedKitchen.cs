using System;
using BanishSystem;
using UnityEngine;

public class HandleBanishFinishedKitchen : MonoBehaviour
{
    [SerializeField] private GameObject _babaika;
    private void Start()
    {
        BanishManager.BanishFinished += () =>
        {
            Debug.Log("Изгнание в кухне завершено");
            GlobalVariables.ChertBanished = true;
            Destroy(_babaika);
        };
    }
}