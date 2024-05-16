using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorOnFedorRoom : MonoBehaviour, InteractionAbstraction
{
    private Rigidbody2D _playerRigidbody2D;
    [SerializeField] private Transform streetTeleport;
    [SerializeField] private Light2D globalLight2D;

    private void Start()
    {
        _playerRigidbody2D = Player.Instance.GetComponent<Rigidbody2D>();
    }


    public void Interact()
    {
        if (Inventory.Inventory.Instance.IsFullInventory())
        {
            globalLight2D.intensity = 0.15f;
            InteractionSoundScript.Instance.openDoorSound.Play();
            _playerRigidbody2D.position = streetTeleport.position;
        }
        else
            BubbleText.Instance.ShowMessage("Мне надо собрать мои вещи");
        
    }
}
