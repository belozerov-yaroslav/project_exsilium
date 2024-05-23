using System;
using UnityEngine;

public class FirstVisit : MonoBehaviour
{
    private void Start()
    {
        SaveSystem.ResetGlobals();
        if (GlobalVariables.NotFirstMansion)
            return;
        CustomInputInitializer.CustomInput.Player.ItemChange.performed += 
            _ => Player.BubbleText.ShowMessage("Мне надо отдохнуть");
        Inventory.Inventory.Instance.IsLocked = true;
    }
}