    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Random = UnityEngine.Random;

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
                var t = Random.Range(0, _messages.Count);
                Debug.Log(t);
                _messages[t].Play();
                yield return new WaitForSeconds(Random.Range(10, 20));
            }
        }
    }