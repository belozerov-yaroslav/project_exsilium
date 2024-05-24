using UnityEngine;


public static class SaveSystem
{
    public static void InitGlobals()
    {
        GlobalVariables.LihoBanished = PlayerPrefs.GetInt("lihoBanished") == 1;
        GlobalVariables.MorokBanished = PlayerPrefs.GetInt("morokBanished") == 1;
        GlobalVariables.MertvyakBanished= PlayerPrefs.GetInt("mertvyakBanished") == 1;
        GlobalVariables.ChertBanished = PlayerPrefs.GetInt("chertBanished") == 1;
        GlobalVariables.NotFirstMansion = PlayerPrefs.GetInt("notFirstMansion") == 1;
        GlobalVariables.Slept = PlayerPrefs.GetInt("slept") == 1;
        GlobalVariables.CupFall = PlayerPrefs.GetInt("cupFall") == 1;
        GlobalVariables.IsKeyCollected = PlayerPrefs.GetInt("isKeyCollected") == 1;
        GlobalVariables.IsSafeNoteRead = PlayerPrefs.GetInt("isSafeNoteRead") == 1;
        GlobalVariables.IsPaintingRemoved = PlayerPrefs.GetInt("isPaintingRemoved") == 1;
        GlobalVariables.IsSafeOpen = PlayerPrefs.GetInt("isSafeOpen") == 1; 
        GlobalVariables.IsRevolverCollected = PlayerPrefs.GetInt("isRevolverCollected") == 1;
    }

    public static void SaveGlobal(string name, bool state)
    {
        PlayerPrefs.SetInt(name, state ? 1 : 0);
    }

    public static void ResetGlobals()
    {
        GlobalVariables.LihoBanished = false;
        GlobalVariables.MorokBanished = false;
        GlobalVariables.MertvyakBanished = false;
        GlobalVariables.ChertBanished = false;
        GlobalVariables.NotFirstMansion = false;
        GlobalVariables.Slept = false;
        GlobalVariables.CupFall = false;
        GlobalVariables.IsKeyCollected = false;
        GlobalVariables.IsSafeNoteRead = false;
        GlobalVariables.IsPaintingRemoved = false;
        GlobalVariables.IsSafeOpen = false; 
        GlobalVariables.IsRevolverCollected = false;
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