using System;
using System.Collections;
using System.Collections.Generic;
using GameStates;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private List<GameState> _gameStates;
    private readonly Stack<GameState> _statesStack = new Stack<GameState>();
    public static GameStateMachine Instance { get; private set; }
    
    public void Start()
    {
        CustomInputInitializer.CustomInput.Player.Disable();
        CustomInputInitializer.CustomInput.Note.Disable();
        CustomInputInitializer.CustomInput.Bestiary.Disable();
        CustomInputInitializer.CustomInput.Dialogue.Disable();
        CustomInputInitializer.CustomInput.SlideShow.Disable();
        CustomInputInitializer.CustomInput.Global.Enable();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _gameStates.ForEach(state => state.OnTransition += StateTransition);
        _statesStack.Push(_gameStates.Find(state => state is DefaultState));
        _statesStack.Peek().TurnOn();
    }

    public void Awake()
    {
        if(Instance != null)
            Debug.LogError("Two GameStateMachine at scene");
        Instance = this;
    }

    public void StateTransition(GameState state)
    {
        if (state == null)
        {
            _statesStack.Pop().TurnOff();
            _statesStack.Peek().TurnOn();
        }
        else
        {
            _statesStack.Peek().TurnOff();
            _statesStack.Push(state);
            state.TurnOn();
        }
    }
}
