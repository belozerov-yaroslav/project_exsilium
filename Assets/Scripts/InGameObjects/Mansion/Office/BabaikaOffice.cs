using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace InGameObjects.Mansion.Office
{
    public class BabaikaOffice : MonoBehaviour
    {
        [SerializeField] private AudioSource flameSound;
        [SerializeField] private GameObject steps;
        [SerializeField] private Animator ashAnimator;
        [SerializeField] private Animator cameraAnimator;
        [FormerlySerializedAs("stinkyObject")] [SerializeField] private PeriodicPhrases periodicPhrases;
        private static readonly int Appear = Animator.StringToHash("Appear");
        private static readonly int Headache = Animator.StringToHash("Headache");

        private void Start()
        {
            cameraAnimator.SetBool(Headache, true);
        }

        public void TurnOff()
        {
            cameraAnimator.SetBool(Headache, false);
            periodicPhrases.StopPhrases();
            flameSound.Play();
            Destroy(steps);
            ashAnimator.SetTrigger(Appear);
        }
    }
}