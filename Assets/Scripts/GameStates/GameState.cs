using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : MonoBehaviour
{
    public virtual event Action<GameState> OnTransition;
    public abstract void TurnOn();
    public abstract void TurnOff();
    
    public static GameState Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
            Debug.LogWarning("Found more than one state in the scene");
        Instance = this;
    }

    protected void Transite(GameState gameState)
    {
        TurnOff(); 
        OnTransition(null);
    }
}