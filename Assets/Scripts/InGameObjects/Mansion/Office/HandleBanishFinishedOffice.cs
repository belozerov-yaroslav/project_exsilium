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
            Debug.Log("Изгнание в офисе завершилось");
            GlobalVariables.MertvyakBanished = true;
            BanishManager.BanishFinished -= HandleBanish;
        }

        private void OnDestroy()
        {
            BanishManager.BanishFinished -= HandleBanish;
        }
    }
}