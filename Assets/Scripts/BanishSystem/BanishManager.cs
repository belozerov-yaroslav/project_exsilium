using System;
using Inventory.Items_Classes;
using UnityEngine;

namespace BanishSystem
{
    public class BanishManager : MonoBehaviour
    {
        [SerializeField] private Inventory.Inventory inventory;
        [SerializeField] private int level;
        private BanishStep[] _steps;
        private int _index;
        private bool _finished;
        public void Awake()
        {
            inventory.ItemHasAdded += HandleItemAddendum;
            _steps = BanishStepsCompiler.BuildSteps(level);
            if (_steps.Length == 0) _finished = true;
        }

        private void HandleItemAddendum(Item item)
        {
            if (!_finished) item.WasInteracted += HandleAction;
        }

        private void HandleAction(BanishStep step)
        {
            if (_finished || !_steps[_index].EquivalentTo(step)) return;
            if (_index >= _steps.Length - 1)
            {
                Debug.Log("ПРИЗРАК ИЗГНАН");
                _finished = true;
                BanishFinished?.Invoke();
            }
            else _index++;
        }
        
        public  event Action BanishFinished;
    }
}