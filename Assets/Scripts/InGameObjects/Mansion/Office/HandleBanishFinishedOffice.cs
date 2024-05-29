using System;
using BanishSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace InGameObjects.Mansion.Office
{
    public class HandleBanishFinishedOffice : MonoBehaviour
    {
        [SerializeField] private BabaikaOffice babaika;
        private void Start()
        {
            BanishManager.BanishFinished += HandleBanish;
        }

        private void HandleBanish()
        {
            babaika.TurnOff();
            InteractionSoundScript.Instance.banishFinishedSound.Play();
            GlobalVariables.MertvyakBanished = true;
            if (GlobalVariables.ChertBanished && GlobalVariables.MorokBanished)
                Player.BubbleText.ShowMessage("Уже поздно, мне надо идти спать");
            BanishManager.BanishFinished -= HandleBanish;
        }

        private void OnDestroy()
        {
            BanishManager.BanishFinished -= HandleBanish;
        }
    }
}