using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonSound : MonoBehaviour
{
    public void PlaySound()
    {
        InteractionSoundScript.Instance.PlayMenuButtonSound();
    }
    
}
