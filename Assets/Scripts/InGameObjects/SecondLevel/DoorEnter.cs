using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class DoorEnter : MonoBehaviour, IInteraction
{
    public static bool IsBanishComplete;
    public static bool IsDialogComplete = true;
    
    [SerializeField] private string sceneName;

    public void Interact()
    {
        var message = "";
        if (!Inventory.Inventory.Instance.IsFullInventory())
            message = "Я не могу оставить свои вещи";
        if (!IsDialogComplete)
            message = "Надо поговорить с Мари";
        if (!IsBanishComplete)
            message = "Я еще не изгнал демона";
        if (Inventory.Inventory.Instance.IsFullInventory() && IsBanishComplete && IsDialogComplete)
        {
            MusicManager.Instance.ChangeLevelMusic(sceneName);
            SaveSystem.SaveSceneState(sceneName);
            AmbientScript.Instance.AppearAmbient(sceneName);
            SceneManager.LoadScene(sceneName);
            InteractionSoundScript.Instance.openDoorSound.Play();
        }
        else
            Player.BubbleText.ShowMessage(message);
        
    }
}