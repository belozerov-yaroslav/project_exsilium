using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    [SerializeField] private string message;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Player.BubbleText.ShowMessage(message);
    }
}
