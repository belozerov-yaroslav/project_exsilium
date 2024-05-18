using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class NewGameConfirmation : MonoBehaviour
{
    [SerializeField] public Canvas canvas;
    
    
    public void ConfirmNewGame()
    {
        InteractionSoundScript.Instance.PlayMenuButtonSound();
        canvas.gameObject.SetActive(true);
    }
    
    public void CloseConfirmation()
    {
        InteractionSoundScript.Instance.PlayMenuButtonSound();
        canvas.gameObject.SetActive(false);
    }
}
