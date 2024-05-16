using UnityEngine;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private string startSceneName;
    public void LoadScene()
    {
        if (SaveSystem.LoadSceneState() == "")
            SaveSystem.SaveSceneState(startSceneName);
        LevelLoader.Instance.LoadLevelWithLoadingScreen(SaveSystem.LoadSceneState());
    }
    
    public void NewGame()
    {
        SaveSystem.ResetGlobals();
        SaveSystem.SaveSceneState(startSceneName);
        LevelLoader.Instance.LoadLevelWithLoadingScreen(SaveSystem.LoadSceneState());
    }
}
