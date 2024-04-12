using UnityEngine;

namespace Interactions
{
    public class KnifeInteraction : MonoBehaviour, InteractionAbstraction
    {
        public void Interact()
        {
            Debug.Log("На нож нажали");
        }
    }
}
