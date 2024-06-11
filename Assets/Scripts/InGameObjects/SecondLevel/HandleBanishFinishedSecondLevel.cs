using System;
using BanishSystem;
using UnityEngine;

public class HandleBanishFinishedSecondLevel : MonoBehaviour
{
    [SerializeField] private GameObject _babaika;
    private void Start()
    {
        BanishManager.BanishFinished += Handle;
    }

    private void OnDestroy()
    {
        BanishManager.BanishFinished -= Handle;
    }

    private void Handle()
    {
        QuestMarkerManager.Instance.SetCurrentMarker("Забрать награду и выйти из кабака");
        InteractionSoundScript.Instance.banishFinishedSound.Play();
        DialogueManager.instance.SetVariableState("liho_banished", new Ink.Runtime.BoolValue(true));
        DoorEnter.IsBanishComplete = true;
        Destroy(_babaika);
    }
}