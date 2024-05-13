using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGameObjects.FirstLevel
{
    public class DoorToPub : MonoBehaviour, InteractionAbstraction
    {
        [SerializeField] private string pubLevelName;
        [SerializeField] private AudioSource doorSound;

        public void Start()
        {
            doorSound = GetComponent<AudioSource>();
        }

        public void Interact()
        {
            doorSound.Play();
            SaveSystem.SaveSceneState(pubLevelName);
            SceneManager.LoadScene(pubLevelName);
        }
    }
}