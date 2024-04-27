using System;
using System.Collections.Generic;
using UnityEngine;

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
    
}