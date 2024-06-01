using System;
using System.Collections;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Vasil : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;
    private static readonly int WalkInHash = Animator.StringToHash("WalkIn");
    public static Vasil Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two Vasil in the scene");
        Instance = this;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }

    public IEnumerator WalkIn()
    {
        yield return new WaitForSeconds(1.5f);
        InteractionSoundScript.Instance.openDoorSound.Play();
        gameObject.SetActive(true);
        _animator.SetTrigger(WalkInHash);
    }

    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;
    private void OnAnimationEnd()
    {
        DialogueManager.GetInstance().SetVariableState("take_revolver", new BoolValue(GlobalVariables.IsRevolverCollected));
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, transform.position, Player.Instance.transform.position, false);
        DialogueManager.GetInstance().OnDialogueEnd += Ending;
    }

    private void Ending()
    {
        DialogueManager.GetInstance().OnDialogueEnd -= Ending;
        if (((BoolValue)DialogueManager.GetInstance().GetVariableState("green_ending")).value)
        {
            StartCoroutine(Disappear());
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

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1f);
        InteractionSoundScript.Instance.banishFinishedSound.Play();
        StartCoroutine(ChangeValueSmooth.Change(1f, 0f,
            value => _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, value),
            0.5f));
        yield return new WaitForSeconds(0.5f);
        global::Ending.Instance.GreenEnding();
    }
}