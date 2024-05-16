using UnityEngine;


public static class SaveSystem
{
    public static void InitGlobals()
    {
        GlobalVariables.LihoBanished = PlayerPrefs.GetInt("lihoBanished") == 1;
    }

    public static void SaveGlobal(string name, bool state)
    {
        PlayerPrefs.SetInt(name, state ? 1 : 0);
    }

    public static void ResetGlobals()
    {
        GlobalVariables.LihoBanished = false;
    }

    public static void SaveSceneState(string sceneName)
    {
        PlayerPrefs.SetString("sceneState", sceneName);
    }

    public static string LoadSceneState()
    {
        return PlayerPrefs.GetString("sceneState");
    }
}