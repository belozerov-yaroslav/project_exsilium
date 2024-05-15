using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGameObjects.FirstLevel
{
    public class DoorToPub : MonoBehaviour, InteractionAbstraction
    {
        [SerializeField] private string pubLevelName;

        public void Interact()
        {
            if (Inventory.Inventory.Instance.IsFullInventory())
            {
                InteractionSoundScript.Instance.openDoorSound.Play();
                SaveSystem.SaveSceneState(pubLevelName);
                SceneManager.LoadScene(pubLevelName);
            }
            else
                BubbleText.Instance.ShowMessage("Я не могу оставить свои вещи");
        }
    }
}