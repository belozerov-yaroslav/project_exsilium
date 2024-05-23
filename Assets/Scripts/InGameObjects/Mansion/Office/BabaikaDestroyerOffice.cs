using System;
using UnityEngine;

public class BabaikaDestroyerOffice : MonoBehaviour
{
    private void Start()
    {
        if (!GlobalVariables.MertvyakBanished)
            return;
    }
}