using UnityEngine;

public class LetterInteraction : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private string _mansionLevelName = "Level5";
    public void Interact()
    {
        LevelLoader.Instance.LoadLevelWithLoadingScreen(_mansionLevelName);
    }
}