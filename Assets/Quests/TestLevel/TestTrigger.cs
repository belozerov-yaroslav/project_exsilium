using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    [SerializeField] private Collider2D playerTrigger;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other == playerTrigger) PlayerEntered?.Invoke();
    }

    public event Action PlayerEntered;
}
