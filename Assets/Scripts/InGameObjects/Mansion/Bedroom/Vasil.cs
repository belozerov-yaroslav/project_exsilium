using System;
using Ink.Runtime;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Vasil : MonoBehaviour
{
    public static Animator Animator { get; private set; }

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;
    private void OnAnimationEnd()
    {
        DialogueManager.GetInstance().SetVariableState("take_revolver", new BoolValue(GlobalVariables.IsRevolverCollected));
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        DialogueManager.GetInstance().OnDialogueEnd += Ending;
    }

    private void Ending()
    {
        DialogueManager.GetInstance().OnDialogueEnd -= Ending;
        if (((BoolValue)DialogueManager.GetInstance().GetVariableState("green_ending")).value)
        {
            global::Ending.Instance.GreenEnding();
        }
        else if (((BoolValue)DialogueManager.GetInstance().GetVariableState("orange_ending")).value)
        {
            global::Ending.Instance.OrangeEnding();
        }
        else if (((BoolValue)DialogueManager.GetInstance().GetVariableState("red_ending")).value)
        {
            global::Ending.Instance.RedEnding();
        }
    }
}