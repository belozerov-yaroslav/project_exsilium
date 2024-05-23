using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomDoorInteraction : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private string _levelName;
    public static string LastSceneName { get; private set; }

    public void Interact()
    {
        LastSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_levelName);
        InteractionSoundScript.Instance.openDoorSound.Play();
        if(LastSceneName != _levelName)
            MusicManager.Instance.ChangeLevelMusic(_levelName);
    }
}
