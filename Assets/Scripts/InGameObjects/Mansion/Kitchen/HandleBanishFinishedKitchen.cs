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
        InteractionSoundScript.Instance.banishFinishedSound.Play();
        GlobalVariables.ChertBanished = true;
        if (GlobalVariables.MertvyakBanished && GlobalVariables.MorokBanished)
            Player.BubbleText.ShowMessage("Уже поздно, мне надо идти спать");
        Destroy(_babaika);
        
    }

    private void OnDestroy()
    {
        BanishManager.BanishFinished -= Handle;
    }
}