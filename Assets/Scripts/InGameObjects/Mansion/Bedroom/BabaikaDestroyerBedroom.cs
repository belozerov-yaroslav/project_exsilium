using System;
using UnityEngine;

public class BabaikaDestroyerBedroom : MonoBehaviour
{
    [SerializeField] private GameObject _babaika;
    private void Start()
    {
        if (!GlobalVariables.MorokBanished)
            return;
        Destroy(_babaika);
    }
}