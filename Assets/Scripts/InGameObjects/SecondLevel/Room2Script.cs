using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Script : MonoBehaviour
{
    [SerializeField] private GameObject shadow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerInteraction"))
            Destroy(shadow);
    }
}
