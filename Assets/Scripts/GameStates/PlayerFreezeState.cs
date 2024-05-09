using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameStates
{
    public class PlayerFreezeState : GameState
    {
        public static GameState Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
                Debug.LogWarning("Found more than one state in the scene");
            Instance = this;
        }

        public override void TurnOn()
        {
        }

        public override void TurnOff()
        {
        }
    }
}