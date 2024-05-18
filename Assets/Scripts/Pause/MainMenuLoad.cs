using UnityEngine;

public class MainMenuLoad : MonoBehaviour
{
    [SerializeField] private string _mainMenuName = "MainMenu";
    public void Load()
    {
        Time.timeScale = 1f;
        LevelLoader.Instance.LoadLevelWithLoadingScreen(_mainMenuName);
    }
}