using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetMansionDoor : MonoBehaviour, InteractionAbstraction
{
    public void Interact()
    {
        LevelLoader.Instance.LoadLevelWithLoadingScreen("Level6");
    }
}
