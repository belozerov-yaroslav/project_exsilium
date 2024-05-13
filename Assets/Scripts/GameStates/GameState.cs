using System;
using System.Collections.Generic;
using GameStates;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class GameState : MonoBehaviour
{
    public event Action<GameState> OnTransition;
    public abstract void TurnOn();
    public abstract void TurnOff();
    protected void Transite(GameState gameState)
    {
        //TurnOff();
        OnTransition?.Invoke(gameState);
    }

    protected void OnPausePressed(InputAction.CallbackContext callbackContext)
    {
        Transite(PauseState.Instance);
    }
    
}