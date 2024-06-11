using UnityEditor;
using UnityEngine;
using PauseState = GameStates.PauseState;

public class LastSaveLoad : MonoBehaviour
{
    public void Load()
    {
        Time.timeScale = 1f;
        QuestMarkerManager.Instance.SetCurrentMarker(GlobalVariables.QuestMarker);
        LevelLoader.Instance.LoadLevelWithLoadingScreen(SaveSystem.LoadSceneState());
    }
}