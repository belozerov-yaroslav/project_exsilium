using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstVisit : MonoBehaviour
{
    public static FirstVisit Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two FirstVisit in the scene");
        Instance = this;
    }

    private void Start()
    {
        SaveSystem.InitGlobals();
        if (GlobalVariables.NotFirstMansion)
            return;
        CustomInputInitializer.CustomInput.Player.ItemChange.performed += ShowBubble;
        CustomInputInitializer.CustomInput.Player.ItemScroll.performed += ShowBubble;
        Inventory.Inventory.Instance.IsLocked = true;
    }

    private void ShowBubble(InputAction.CallbackContext callbackContext)
    {
        Player.BubbleText.ShowMessage("Мне надо отдохнуть");
    }

    public void StopWorking()
    {
        Inventory.Inventory.Instance.IsLocked = false;
        CustomInputInitializer.CustomInput.Player.ItemChange.performed -= ShowBubble;
        CustomInputInitializer.CustomInput.Player.ItemScroll.performed -= ShowBubble;
    }
}