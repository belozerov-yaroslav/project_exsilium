using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGameObjects.FirstLevel
{
    public class DoorToPub : MonoBehaviour, InteractionAbstraction
    {
        [SerializeField] private string pubLevelName;
        public void Interact()
        {
            SceneManager.LoadScene(pubLevelName);
        }
    }
}