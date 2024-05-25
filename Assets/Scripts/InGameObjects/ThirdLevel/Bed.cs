using UnityEngine;

public class Bed : MonoBehaviour, IInteraction
{
    public void Interact()
    {
        LevelLoader.Instance.LoadLevelWithLoadingScreen("Level4");
    }
}