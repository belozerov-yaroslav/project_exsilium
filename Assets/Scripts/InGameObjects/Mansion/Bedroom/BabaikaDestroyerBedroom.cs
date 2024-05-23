using System;
using UnityEngine;

public class BabaikaDestroyerBedroom : MonoBehaviour
{
    private void Start()
    {
        if (!GlobalVariables.MorokBanished)
            return;
    }
}