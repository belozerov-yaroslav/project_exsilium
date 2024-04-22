using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialoguePanel dialoguePanel;
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    private const string QUEST_GIVE_TAG = "quest_give";
    private const string QUEST_FINISH_TAG = "quest_finish";
    private const string CALL_FUNCTION_TAG = "call";

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private DialogueVariables dialogueVariables;
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
        }
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        }
        if (currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.Show();
        dialogueVariables.StartListening(currentStory);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.Hide();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // set text for the current dialogue line
            dialoguePanel.DisplayMessage(currentStory.Continue());
            // HandleTags(currentStory.currentTags);
            // display choices, if any, for this dialogue line
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        List<string> strChoices = new List<string>();
        foreach (Choice choice in currentChoices)
        {
            strChoices.Add(choice.text);
        }
        dialoguePanel.DisplayChoices(strChoices);
    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
    // private void HandleTags(List<string> currentTags)
    // {
    //     // loop through each tag and handle it accordingly
    //     foreach (string tag in currentTags)
    //     {
    //         Debug.Log("handle");
    //         // parse the tag
    //         string[] splitTag = tag.Split(':');
    //         if (splitTag.Length != 2)
    //         {
    //             Debug.LogError("Tag could not be appropriately parsed: " + tag);
    //         }
    //         string tagKey = splitTag[0].Trim();
    //         string tagValue = splitTag[1].Trim();
    //
    //         // handle the tag
    //         switch (tagKey)
    //         {
    //             case QUEST_GIVE_TAG:
    //                 QuestManager.Instance.AddQuest(tagValue);
    //                 break;
    //             case QUEST_FINISH_TAG:
    //                 QuestManager.Instance.FinishQuest(tagValue);
    //                 break;
    //             case CALL_FUNCTION_TAG:
    //                 Debug.Log("��������");
    //                 SpecialFunctions.Instance.CallFunction(tagValue);
    //                 break;
    //             default:
    //                 Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
    //                 break;
    //         }
    //     }
    // }
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

    // This method will get called anytime the application exits.
    // Depending on your game, you may want to save variable state in other places.
    public void OnApplicationQuit()
    {
        dialogueVariables.SaveVariables();
    }
}
