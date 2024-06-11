using UnityEngine;

public class LetterInteraction : MonoBehaviour, IInteraction
{
    [SerializeField] private string _mansionLevelName = "Level5";
    public void Interact()
    {
        QuestMarkerManager.Instance.SetCurrentMarker("Найти кровать и лечь спать");
        SaveSystem.SaveSceneState(_mansionLevelName);
        LevelLoader.Instance.LoadLevelWithLoadingScreen(_mansionLevelName);
    }
}