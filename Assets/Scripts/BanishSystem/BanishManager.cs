using System;
using Inventory.Items_Classes;
using UnityEngine;

namespace BanishSystem
{
    public class BanishManager : MonoBehaviour
    {
        [SerializeField] private Inventory.Inventory inventory;
        [SerializeField] private int level;
        [SerializeField] private Item[] items;
        private BanishStep[] _steps;
        private BanishStep[] _crushingFactors;
        private int _index;
        private bool _finished;
        private const int GhostTolerance = 10;
        private int _currentMistakesCost;

        public void Awake()
        {
            _steps = BanishStepsCompiler.BuildSteps(level);
            _crushingFactors = BanishStepsCompiler.BuildFactors(level);
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
                    Debug.Log("ПРИЗРАК ИЗГНАН");
                    _finished = true;
                    BanishFinished?.Invoke();
                }
                else _index++;
            }
            else
                for (var i = 0; i < _index; i++)
                    if (_steps[i].EquivalentTo(step))
                    {
                        _index = i + 1;
                        return;
                    }

            HandleMistake(step);
        }

        private void HandleMistake(BanishStep step)
        {
            foreach (var factor in _crushingFactors)
            {
                if (factor.EquivalentTo(step)) _currentMistakesCost += 2;
                break;
            }

            _currentMistakesCost += 2;
            if (_currentMistakesCost >= GhostTolerance) HandleBanishFailure();
        }

        private void HandleBanishFailure()
        {
            Debug.Log("ИЗГНАНИЕ ПРОВАЛИЛОСЬ");
            _finished = true;
        }

        public event Action BanishFinished;
    }
}