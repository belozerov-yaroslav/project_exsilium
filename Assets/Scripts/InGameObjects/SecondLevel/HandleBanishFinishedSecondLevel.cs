using System;
using BanishSystem;
using UnityEngine;

public class HandleBanishFinishedSecondLevel : MonoBehaviour
{
    [SerializeField] private GameObject _babaika;
    private void Start()
    {
        BanishManager.BanishFinished += () =>
        {
            DialogueManager.instance.SetVariableState("liho_banished", new Ink.Runtime.BoolValue(true));
            DoorEnter.IsBanishComplete = true;
            Destroy(_babaika);
        };
    }
}