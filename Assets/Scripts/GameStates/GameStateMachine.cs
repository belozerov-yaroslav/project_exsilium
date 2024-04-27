using System;
using System.Collections;
using System.Collections.Generic;
using GameStates;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private List<GameState> _gameStates;
    private Stack<GameState> _statesStack;

    public void Awake()
    {
        _statesStack.Push(_gameStates.Find(state => state is DefaultState));
        
        _statesStack.Peek().OnTransition += StateTransition;
    }

    private void StateTransition(GameState state)
    {
        
    }
    public CustomInput GetInput()
    {
        return null;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
