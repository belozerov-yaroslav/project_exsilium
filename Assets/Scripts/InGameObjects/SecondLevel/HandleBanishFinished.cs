using System;
using BanishSystem;
using UnityEngine;

public class HandleBanishFinished : MonoBehaviour
{
    private void Start()
    {
        BanishManager.BanishFinished += () =>
        {
            DialogueManager.instance.SetVariableState("liho_banished", new Ink.Runtime.BoolValue(true));
            DoorEnter.IsBanishComplete = true;
        };
    }
}