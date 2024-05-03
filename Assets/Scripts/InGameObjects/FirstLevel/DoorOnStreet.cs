using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOnStreet : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Transform roomTeleport;

    public void Interact()
    {
        player.position = roomTeleport.position;
    }
}
