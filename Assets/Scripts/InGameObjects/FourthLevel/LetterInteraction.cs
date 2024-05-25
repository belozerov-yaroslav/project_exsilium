using UnityEngine;

public class LetterInteraction : MonoBehaviour, IInteraction
{
    [SerializeField] private string _mansionLevelName = "Level5";
    public void Interact()
    {
        SaveSystem.SaveSceneState(_mansionLevelName);
        LevelLoader.Instance.LoadLevelWithLoadingScreen(_mansionLevelName);
    }
}