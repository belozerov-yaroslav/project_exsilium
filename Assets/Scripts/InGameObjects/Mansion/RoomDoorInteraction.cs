using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomDoorInteraction : MonoBehaviour, InteractionAbstraction
{
    [SerializeField] private string _levelName;
    public static string LastSceneName { get; private set; }

    public virtual void Interact()
    {
        if (!Inventory.Inventory.Instance.IsFullInventory())
        {
            Player.BubbleText.ShowMessage("Я не могу оставить свои вещи");
            return;
        }
        LastSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_levelName);
        InteractionSoundScript.Instance.openDoorSound.Play();
        if(LastSceneName != _levelName)
            MusicManager.Instance.ChangeLevelMusic(_levelName);
    }
}
