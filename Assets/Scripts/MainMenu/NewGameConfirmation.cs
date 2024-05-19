using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class NewGameConfirmation : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    
    
    public void ConfirmNewGame()
    {
        canvas.gameObject.SetActive(true);
    }
    
    public void CloseConfirmation()
    {
        canvas.gameObject.SetActive(false);
    }
}
