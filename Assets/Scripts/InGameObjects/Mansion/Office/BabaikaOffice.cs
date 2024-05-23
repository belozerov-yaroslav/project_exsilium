using System;
using UnityEngine;

namespace InGameObjects.Mansion.Office
{
    public class BabaikaOffice : MonoBehaviour
    {
        [SerializeField] private AudioSource flameSound;
        [SerializeField] private GameObject steps;
        [SerializeField] private Animator ashAnimator;
        [SerializeField] private Animator cameraAnimator;
        [SerializeField] private StinkyObject stinkyObject;
        private static readonly int Appear = Animator.StringToHash("Appear");
        private static readonly int Headache = Animator.StringToHash("Headache");

        private void Start()
        {
            cameraAnimator.SetBool(Headache, true);
        }

        public void TurnOff()
        {
            cameraAnimator.SetBool(Headache, false);
            stinkyObject.StopStink();
            flameSound.Play();
            Destroy(steps);
            ashAnimator.SetTrigger(Appear);
        }
    }
}