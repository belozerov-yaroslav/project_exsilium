using UnityEngine;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private string startSceneName;
    public void LoadScene()
    {
        if (SaveSystem.LoadSceneState() == "")
        {
            SaveSystem.SaveSceneState(startSceneName);
            SaveSystem.ResetGlobals();
        }
        QuestMarkerManager.Instance.text.text = GlobalVariables.QuestMarker;
        LevelLoader.Instance.LoadLevelWithLoadingScreen(SaveSystem.LoadSceneState());
    }
    
    public void NewGame()
    {
        SaveSystem.ResetGlobals();
        QuestMarkerManager.Instance.text.text = GlobalVariables.QuestMarker;
        SaveSystem.SaveSceneState(startSceneName);
        LevelLoader.Instance.LoadLevelWithLoadingScreen(SaveSystem.LoadSceneState());
    }
}
