using UnityEngine;

public class Bed : MonoBehaviour, InteractionAbstraction
{
    public void Interact()
    {
        LevelLoader.Instance.LoadLevelWithLoadingScreen("Level4");
    }
}