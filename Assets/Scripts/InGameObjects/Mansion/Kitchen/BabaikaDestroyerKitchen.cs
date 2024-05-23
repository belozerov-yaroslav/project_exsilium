using System;
using UnityEngine;

public class BabaikaDestroyerKitchen : MonoBehaviour
{
    [SerializeField] private GameObject cup;
    private void Start()
    {
        if (!GlobalVariables.ChertBanished)
            return;
        cup.GetComponent<Animator>().Play("IdleBroken");
    }
}