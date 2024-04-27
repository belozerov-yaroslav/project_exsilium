using System;
using System.Collections;
using System.Collections.Generic;
using GameStates;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private List<GameState> _gameStates;
    private readonly Stack<GameState> _statesStack = new Stack<GameState>();

    public void Start()
    {
        CustomInputInitializer.CustomInput.Player.Disable();
        CustomInputInitializer.CustomInput.Bestiary.Disable();
        _gameStates.ForEach(state => state.OnTransition += StateTransition);
        _statesStack.Push(_gameStates.Find(state => state is DefaultState));
        _statesStack.Peek().TurnOn();
    }

    private void StateTransition(GameState state)
    {
        if (state == null)
        {
            _statesStack.Pop();
            _statesStack.Peek().TurnOn();
        }
        else
        {
            _statesStack.Push(state);
            state.TurnOn();
        }
    }
}
