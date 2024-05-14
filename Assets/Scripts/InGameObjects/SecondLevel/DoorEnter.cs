using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class DoorEnter : MonoBehaviour, InteractionAbstraction
{
    public static bool IsBanishComplete;
    public static bool IsDialogComplete = true;
    
    [SerializeField] private string sceneName;
    private AudioSource _doorSound;
    private void Awake()
    {
        _doorSound = GetComponent<AudioSource>();
    }


    public void Interact()
    {
        var message = "";
        if (!Inventory.Inventory.Instance.IsFullInventory())
            message = "Мне надо собрать мои вещи";
        if (!IsDialogComplete)
            message = "Надо поговорить с Мари";
        if (!IsBanishComplete)
            message = "Я еще не изгнал демона";
        if (Inventory.Inventory.Instance.IsFullInventory() && IsBanishComplete && IsDialogComplete)
        {
            SceneManager.LoadScene(sceneName);
            _doorSound.Play();
        }
        else
            BubbleText.Instance.ShowMessage(message);
        
    }
}