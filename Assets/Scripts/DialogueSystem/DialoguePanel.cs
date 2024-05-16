using System;
using System.Collections;
using System.Collections.Generic;
using DialogueSystem;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePanel : MonoBehaviour
{
    private static DialoguePanel instance;
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject textExample;
    [SerializeField] private GameObject choiceBtnExample;
    [SerializeField] private float spaceBetweenMessages = 15f;
    [SerializeField] private float btnTextMargin = 10f;
    [SerializeField] private float startSpace = 15f;
    [SerializeField]private AudioSource buttonSound;
    private readonly List<GameObject> currentMessages = new();
    private readonly List<GameObject> currentChoiceButtons = new();
    private Stack<float> lastMessagePos = new(new float[] { 0 });

    private float contentHeight = 0;
    private DialoguePanelAnimation _dialoguePanelAnimation;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Panel in the scene");
        }
        lastMessagePos.Push(-startSpace);
        instance = this;
    }

    private void Start()
    {
        _dialoguePanelAnimation = GetComponentInChildren<DialoguePanelAnimation>();
    }

    public static DialoguePanel GetInstance()
    {
        return instance;
    }

    public void Show()
    {
        _dialoguePanelAnimation.TurnOn();
        dialogueCanvas.enabled = true;
    }

    public void Hide()
    {
        dialogueCanvas.enabled = false;
        DeleteChoiceButtons();
        DeleteAllMessages();
    }

    public void DisplayMessage(DialogueLine dialogueLine)
    {
        if (string.IsNullOrWhiteSpace(dialogueLine.Text))
            return;

        var newTextElement = Instantiate(textExample, content.transform);
        var textElem = newTextElement.GetComponent<TextMeshProUGUI>();
        
        textElem.text = dialogueLine.ToString();
        newTextElement.SetActive(true);
        AdjustTransformToTextSize(textElem);
        var textHeight = textElem.rectTransform.rect.height;

        var localPosition = newTextElement.transform.localPosition;
        localPosition = new Vector3(localPosition.x, lastMessagePos.Peek() - spaceBetweenMessages, 0);
        newTextElement.transform.localPosition = localPosition;
        
        lastMessagePos.Push(localPosition.y - textHeight);
        AdjustContentSize(textHeight + spaceBetweenMessages);

        if (dialogueLine.Author != null)
        {
            var elem = DrawAuthorName(dialogueLine, localPosition);
            currentMessages.Add(elem);
        }
        currentMessages.Add(newTextElement);
    }

    private GameObject DrawAuthorName(DialogueLine dialogueLine, Vector3 localPosition)
    {
        var authorTextElement = Instantiate(textExample, content.transform);
        authorTextElement.transform.localPosition = localPosition;
        var authorText = authorTextElement.GetComponent<TextMeshProUGUI>();
        authorText.text = dialogueLine.Author.authorName + ':';
        authorText.color = dialogueLine.Author.Color;
        authorText.fontStyle = FontStyles.Bold;
        authorTextElement.SetActive(true);
        return authorTextElement;
    }

    public void DisplayChoices(List<string> choices)
    {
        int index = 0;
        foreach (string choice in choices)
        {
            GameObject choiceBtn = Instantiate(choiceBtnExample, content.transform);
            choiceBtn.SetActive(true);

            TextMeshProUGUI btnText = choiceBtn.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = choice;
            AdjustTransformToTextSize(btnText);
            var textHeight = btnText.rectTransform.rect.height;
            choiceBtn.GetComponent<RectTransform>()
                .SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textHeight + 2 * btnTextMargin);

            choiceBtn.transform.localPosition = new Vector3(choiceBtn.transform.localPosition.x,
                lastMessagePos.Peek() - spaceBetweenMessages - btnTextMargin, 0);

            var i = index; // c# - гений, эта строка нужна для обхода "особенностей языка", НЕ УБИРАТЬ
            choiceBtn.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(i));
            index += 1;

            AdjustContentSize(spaceBetweenMessages + textHeight + 2 * btnTextMargin);
            lastMessagePos.Push(lastMessagePos.Peek() - spaceBetweenMessages - (textHeight + 2 * btnTextMargin));

            currentChoiceButtons.Add(choiceBtn);
        }
    }

    private void AdjustTransformToTextSize(TextMeshProUGUI text)
    {
        text.ForceMeshUpdate();
        var textHeight = text.GetRenderedValues().y;
        text.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textHeight);
    }

    private void AdjustContentSize(float adjustSize)
    {
        contentHeight += adjustSize + 5;
        content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, contentHeight);
        var newPosition = content.transform.position;
        newPosition.y = Math.Max(newPosition.y, contentHeight);
        content.transform.position = newPosition;
    }

    private void ButtonClicked(int index)
    {
        buttonSound.Play();
        DeleteChoiceButtons();
        DialogueManager.GetInstance().MakeChoice(index);
    }

    private void DeleteChoiceButtons()
    {
        foreach (var choiceButton in currentChoiceButtons)
        {
            Destroy(choiceButton);
            lastMessagePos.Pop();
        }
        currentChoiceButtons.Clear();
        AdjustContentSize(-(contentHeight + lastMessagePos.Peek()));
    }

    private void DeleteAllMessages()
    {
        foreach (var message in currentMessages)
            Destroy(message);

        currentMessages.Clear();
        AdjustContentSize(-contentHeight);
        lastMessagePos.Clear();
        lastMessagePos.Push(-startSpace);
    }
}