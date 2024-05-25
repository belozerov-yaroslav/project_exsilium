    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class PeriodicSound : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> _messages = new();
        [SerializeField] private int maxWaitTime = 20; 
        [SerializeField] private int minWaitTime = 10; 

        private void Awake()
        {
            StartCoroutine(StartSounds());
        }

        public void StopSounds()
        {
            StopAllCoroutines();
        }

        public IEnumerator StartSounds()
        {
            yield return null;
            while (true)
            {
                var t = Random.Range(0, _messages.Count);
                _messages[t].Play();
                yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            }
        }
    }