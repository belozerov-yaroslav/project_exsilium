using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGameObjects.FirstLevel
{
    public class DoorToPub : MonoBehaviour, IInteraction
    {
        [SerializeField] private string pubLevelName;

        public void Interact()
        {
            if (Inventory.Inventory.Instance.IsFullInventory())
            {
                InteractionSoundScript.Instance.openDoorSound.Play();
                AmbientScript.Instance.StopAmbient();
                MusicManager.Instance.ChangeLevelMusic(pubLevelName);
                SaveSystem.SaveSceneState(pubLevelName);
                SceneManager.LoadScene(pubLevelName);
            }
            else
                Player.BubbleText.ShowMessage("Я не могу оставить свои вещи");
        }
    }
}