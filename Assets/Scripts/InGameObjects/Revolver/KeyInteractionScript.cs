using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyInteractionScript : MonoBehaviour, InteractionAbstraction
{
    private void Start()
    {
        if (GlobalVariables.IsKeyCollected) Destroy(gameObject);
    }

    public void Interact()
    {
        InteractionSoundScript.Instance.pickingUpSound.Play();
        GlobalVariables.IsKeyCollected = true;
        string message;
        if (GlobalVariables.IsPaintingRemoved) message = "А вот и ключ";
        else if (GlobalVariables.IsSafeNoteRead) message = "Наверное это ключ от того сейфа";
        else message = "Интересно от какого замка этот ключ";
        Player.BubbleText.ShowMessage(message);
        Destroy(gameObject);
    }
}