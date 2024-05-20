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
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [SerializeField] private DialogueParser _dialogueParser;
    [SerializeField]private AudioSource dialogSound;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    public static DialogueManager instance { get; private set; }

    private DialogueVariables dialogueVariables;

    private List<string> currentTextChoices = new();
    private DialoguePanelAnimation _dialoguePanelAnimation;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.Hide();
        _dialoguePanelAnimation = GetComponentInChildren<DialoguePanelAnimation>();
        _dialoguePanelAnimation.OnTurnOff += ExitDialogueMode;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        dialogSound.Play();
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.Show();
        dialogueVariables.StartListening(currentStory);
        GameStateMachine.Instance.StateTransition(DialogueState.Instance);
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogSound.Play();
        GameStateMachine.Instance.StateTransition(null);
        dialogueVariables.StopListening(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.Hide();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialoguePanel.DisplayMessage(_dialogueParser.ParseLine(currentStory.Continue(), currentStory.currentTags));
            DisplayChoices();
        }
        else
        {
            _dialoguePanelAnimation.TurnOff();
        }
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
        if (currentTextChoices[choiceIndex].StartsWith('*'))
        {
            currentTextChoices.Clear();
            ContinueStory();
        }
        else
        {
            currentTextChoices.Clear();
            ContinueStory();
            ContinueStory();
        }
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
