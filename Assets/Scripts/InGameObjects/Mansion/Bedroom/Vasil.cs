using System;
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
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}