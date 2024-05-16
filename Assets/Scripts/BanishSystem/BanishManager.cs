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
        [SerializeField] private AudioSource heartBeat;
        [SerializeField] private AudioSource deathSound;
        [SerializeField] private CanvasGroup screenEffect;
        [SerializeField] private float volumeStep = 0.1f;
        [SerializeField] private float transparencyStep = 0.1f;
        [SerializeField] private Canvas canvas;
        private BanishStep[] _steps;
        private BanishStep[] _crushingFactors;
        private int _index;
        private bool _finished;
        private const int GhostTolerance = 10;
        private int _currentMistakesCost;
        
        private static readonly int Dead = Animator.StringToHash("Dead");

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

            HandleMistake(step);
        }

        private void HandleMistake(BanishStep step)
        {
            if (_currentMistakesCost == 0)
            {
                canvas.gameObject.SetActive(true);
                heartBeat.Play();
            }
            _currentMistakesCost += 2;
            heartBeat.volume = _currentMistakesCost * volumeStep;
            screenEffect.alpha = _currentMistakesCost * transparencyStep;
            if (_currentMistakesCost >= GhostTolerance) HandleBanishFailure();
        }

        private void HandleBanishFailure()
        {
            deathSound.Play();
            heartBeat.Stop();
            _finished = true;
            GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
            Player.Instance.gameObject.GetComponent<Animator>().SetTrigger(Dead);
            LevelLoader.Instance.LoadLevelWithLoadingScreen(SaveSystem.LoadSceneState());
        }

        public static event Action BanishFinished;
    }
}