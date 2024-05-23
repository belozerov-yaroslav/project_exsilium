using System;
using UnityEngine;

public class BabaikaDestroyerOffice : MonoBehaviour
{
    [SerializeField] private GameObject babaika;
    private void Awake()
    {
        SaveSystem.InitGlobals();
        if (!GlobalVariables.MertvyakBanished)
            return;
        Destroy(babaika);
    }
}