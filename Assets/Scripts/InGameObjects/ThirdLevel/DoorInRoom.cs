using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class DoorInRoom : MonoBehaviour, InteractionAbstraction
{
    private Rigidbody2D _playerRigidbody2D;
    [SerializeField] private Transform roomTeleport;
    [SerializeField] private Light2D globalLight2D;
    
    private AudioSource _doorSound;
    void Start()
    {
        _doorSound = GetComponent<AudioSource>();
        _playerRigidbody2D = Player.Instance.GetComponent<Rigidbody2D>();
    }

    public void Interact()
    {
        if (Inventory.Inventory.Instance.IsFullInventory())
        {
            globalLight2D.intensity = 0.5f;
            _doorSound.Play();
            _playerRigidbody2D.position = roomTeleport.position;
        }
        else
            Player.BubbleText.ShowMessage("Я не могу оставить свои вещи");
    }
}
