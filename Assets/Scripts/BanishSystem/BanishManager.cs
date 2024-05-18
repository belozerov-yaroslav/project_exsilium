using System;
using System.Collections;
using GameStates;
using Inventory.Items_Classes;
using UnityEngine;

namespace BanishSystem
{
    public class BanishManager : MonoBehaviour
    {
        [SerializeField] private Inventory.Inventory inventory;
        [SerializeField] private int level;
        [SerializeField] private Item[] items;
        [SerializeField] private AudioSource banishSound;
        private BanishStep[] _steps;
        private int _index;
        private bool _finished;

        public void Awake()
        {
            _steps = BanishStepsCompiler.BuildSteps(level);
            if (_steps.Length == 0) _finished = true;
        }

        public void Start()
        {
            foreach (var item in items) item.WasInteracted += HandleAction;
        }

        private void HandleAction(BanishStep step)
        {
            if (_finished) return;
            if (_steps[_index].EquivalentTo(step))
            {
                if (_index >= _steps.Length - 1)
                {
                    _finished = true;
                    banishSound.Play();
                    BanishFinished?.Invoke();
                }
                else _index++;
                return;
            }

            for (var i = 0; i < _index; i++)
                if (_steps[i].EquivalentTo(step))
                {
                    _index = i + 1;
                    return;
                }
        }
        

        public static event Action BanishFinished;
    }
}