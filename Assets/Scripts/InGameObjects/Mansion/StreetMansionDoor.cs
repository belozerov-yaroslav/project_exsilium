using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetMansionDoor : MonoBehaviour, InteractionAbstraction
{
    public void Interact()
    {
        SaveSystem.SaveSceneState("Level6");
        LevelLoader.Instance.LoadLevelWithLoadingScreen("Level6");
        InteractionSoundScript.Instance.openDoorSound.Play();
    }
}
