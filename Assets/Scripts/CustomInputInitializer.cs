using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputInitializer : MonoBehaviour
{
    public static CustomInput CustomInput;
    private void Awake()
    {
        if (CustomInput != null)
            Debug.LogError("Two customInputs in scene");
        CustomInput = new CustomInput();
    }

    private void OnDestroy()
    {
        CustomInput.Dispose();
        CustomInput = null;
    }
}
