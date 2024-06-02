using System;
using System.Collections;
using System.Collections.Generic;
using DialogueSystem;
using GameStates;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialoguePanel dialoguePanel;

    [Header("Load Globals JSON")] [SerializeField]
    private TextAsset loadGlobalsJSON;

    [SerializeField] private DialogueParser _dialogueParser;
    [SerializeField] private AudioSource dialogSound;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    public static DialogueManager Instance { get; private set; }

    private DialogueVariables dialogueVariables;

    private List<string> currentTextChoices = new();
    private DialoguePanelAnimation _dialoguePanelAnimation;
    public event Action OnDialogueEnd;

    private bool _cameraRevert = true;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }

        Instance = this;
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }

    public static DialogueManager GetInstance()
    {
        return Instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.Hide();
        _dialoguePanelAnimation = GetComponentInChildren<DialoguePanelAnimation>();
        _dialoguePanelAnimation.OnTurnOff += ExitDialogueMode;
    }
    
    private void OnDestroy()
    {
        Instance = null;
    }

    public void EnterDialogueMode(TextAsset inkJSON, Vector2 tellerPosition, Vector2 listenerPosition,
        bool cameraRevert = true)
    {
        var cameraPosition = (tellerPosition + listenerPosition) / 2 + new Vector2(2.25f, 0.6f);
        CameraMovement.Instance.MoveToPosition(cameraPosition, 0.5f);
        dialogSound.Play();
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.Show();
        dialogueVariables.StartListening(currentStory);
        GameStateMachine.Instance.StateTransition(DialogueState.Instance);
        _cameraRevert = cameraRevert;
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogSound.Play();
        GameStateMachine.Instance.StateTransition(null);
        dialogueVariables.StopListening(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.Hide();
        OnDialogueEnd?.Invoke();
    }

    private DialogueLine ContinueStory()
    {
        if (currentStory.canContinue)
        {
            var dialogueString = _dialogueParser.ParseLine(currentStory.Continue(), currentStory.currentTags);
            dialoguePanel.DisplayMessage(dialogueString);
            DisplayChoices();
            return dialogueString;
        }
        else
        {
            _dialoguePanelAnimation.TurnOff(_cameraRevert);
        }

        return null;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        foreach (Choice choice in currentChoices)
        {
            currentTextChoices.Add(choice.text);
        }

        dialoguePanel.DisplayChoices(currentTextChoices);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        currentTextChoices.Clear();
        var line = new DialogueLine(); 
        while (currentTextChoices.Count == 0 && line != null)
            line = ContinueStory();
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }

        return variableValue;
    }

    public void SetVariableState(string variableName, Ink.Runtime.Object variableValue)
    {
        if (dialogueVariables.variables.ContainsKey(variableName))
        {
            dialogueVariables.variables[variableName] = variableValue;
        }
        else
        {
            Debug.LogWarning("Tried to update variable that wasn't initialized by globals.ink: " + variableName);
        }
    }
}