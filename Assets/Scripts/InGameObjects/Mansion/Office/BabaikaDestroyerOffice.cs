using System;
using UnityEngine;

public class BabaikaDestroyerOffice : MonoBehaviour
{
    [SerializeField] private GameObject babaika;
    private void Awake()
    {
        if (GlobalVariables.Slept && !GlobalVariables.MertvyakBanished)
            return;
        Destroy(babaika);
    }
}