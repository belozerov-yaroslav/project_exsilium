using UnityEngine;

namespace InGameObjects.Mansion.Office
{
    public class StepsOnFloor : MonoBehaviour
    {
        [SerializeField] private AudioSource flameSound;
        [SerializeField] private GameObject steps;
        [SerializeField] private Animator ashAnimator;
        [SerializeField] private StinkyObject stinkyObject;
        private static readonly int Appear = Animator.StringToHash("Appear");

        public void TurnOff()
        {
            stinkyObject.StopStink();
            flameSound.Play();
            Destroy(steps);
            ashAnimator.SetTrigger(Appear);
        }
    }
}