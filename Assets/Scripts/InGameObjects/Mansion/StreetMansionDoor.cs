using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetMansionDoor : MonoBehaviour, IInteraction
{
    public void Interact()
    {
        SaveSystem.SaveSceneState("Level6");
        LevelLoader.Instance.LoadLevelWithLoadingScreen("Level6");
        InteractionSoundScript.Instance.openDoorSound.Play();
    }
}
