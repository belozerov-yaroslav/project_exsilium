using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGameObjects.FirstLevel
{
    public class DoorToPub : MonoBehaviour, InteractionAbstraction
    {
        [SerializeField] private string pubLevelName;
        private AudioSource doorSound;

        public void Start()
        {
            doorSound = GetComponent<AudioSource>();
        }

        public void Interact()
        {
            if (Inventory.Inventory.Instance.IsFullInventory())
            {
                doorSound.Play();
                SceneManager.LoadScene(pubLevelName);
            }
            else
                BubbleText.Instance.ShowMessage("Я не могу оставить свои вещи");
            
        }
    }
}