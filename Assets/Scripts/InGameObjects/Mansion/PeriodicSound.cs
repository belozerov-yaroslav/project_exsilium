    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PeriodicSound : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> _messages = new();

        private void Start()
        {
            StartCoroutine(StartSounds());
        }

        public void StopSounds()
        {
            StopAllCoroutines();
        }

        private IEnumerator StartSounds()
        {
            yield return null;
            while (true)
            {
                _messages[Random.Range(0, _messages.Count-1)].Play();
                yield return new WaitForSeconds(Random.Range(10, 20));
            }
        }
    }