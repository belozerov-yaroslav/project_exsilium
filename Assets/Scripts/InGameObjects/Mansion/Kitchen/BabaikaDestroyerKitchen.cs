using System;
using UnityEngine;

public class BabaikaDestroyerKitchen : MonoBehaviour
{
    [SerializeField] private GameObject _babaika;
    private void Start()
    {
        if (!GlobalVariables.ChertBanished)
            return;
        Destroy(_babaika);
    }
}