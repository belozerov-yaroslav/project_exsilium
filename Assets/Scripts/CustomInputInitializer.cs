using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputInitializer : MonoBehaviour
{
    public CustomInput CustomInput;
    private void Awake()
    {
        CustomInput = new CustomInput();
        CustomInput.Global.BestiaryNavigation.Disable();
    }
}
