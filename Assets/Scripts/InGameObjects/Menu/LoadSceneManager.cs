using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private string _startSceneName;
    public void LoadSampleScene()
    {
        if (SaveSystem.LoadSceneState() == "")
            SaveSystem.SaveSceneState(_startSceneName);
        SceneManager.LoadScene(SaveSystem.LoadSceneState());
    }
}
