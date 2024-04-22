using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePanel : MonoBehaviour
{
    private static DialoguePanel instance;
    [SerializeField] GameObject content;
    [SerializeField] float spaceBetweenMessages = 20f;
    [SerializeField] GameObject textExample;
    [SerializeField] GameObject choiceBtnExample;
    [SerializeField] float btnTextMargin = 5f;
    private List<GameObject> currentMessages = new();
    private List<GameObject> currentChoiceButtons = new();
    private Stack<float> lastMessagePos = new(new float[] { 0 });

    private float contentHeight = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Panel in the scene");
        }

        instance = this;
    }
    public static DialoguePanel GetInstance()
    {
        return instance;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        DeleteChoiceButtons();
        DeleteAllMessages();
    }

    public void DisplayMessage(string message)
    {
        if (message == "")
            return;

        GameObject newTextElement = Instantiate(textExample, content.transform);
        TextMeshProUGUI textElem = newTextElement.GetComponent<TextMeshProUGUI>();
        
        textElem.text = message;
        newTextElement.SetActive(true);
        AdjustTransformToTextSize(textElem);
        var textHeight = textElem.rectTransform.rect.height;

        var localPosition = newTextElement.transform.localPosition;
        localPosition = new Vector3(localPosition.x, lastMessagePos.Peek() - spaceBetweenMessages - textHeight / 2, 0);
        newTextElement.transform.localPosition = localPosition;
        
        lastMessagePos.Push(localPosition.y - textHeight / 2);
        AdjustContentSize(textHeight + spaceBetweenMessages);

        currentMessages.Add(newTextElement);
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
                lastMessagePos.Peek() - spaceBetweenMessages - btnTextMargin - textHeight / 2, 0);

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
        contentHeight += adjustSize;
        content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, contentHeight);
        var newPosition = content.transform.position;
        newPosition.y = Math.Max(newPosition.y, contentHeight);
        content.transform.position = newPosition;
    }

    private void ButtonClicked(int index)
    {
        DeleteChoiceButtons();
        DialogueManager.GetInstance().MakeChoice(index);
    }

    private void DeleteChoiceButtons()
    {
        foreach (GameObject choiceButton in currentChoiceButtons)
        {
            Destroy(choiceButton);
            lastMessagePos.Pop();
        }
        currentChoiceButtons.Clear();
        AdjustContentSize(-(contentHeight + lastMessagePos.Peek()));
    }

    private void DeleteAllMessages()
    {
        foreach (GameObject message in currentMessages)
        {
            Destroy(message);
        }

        currentMessages.Clear();
        lastMessagePos.Push(0);
        AdjustContentSize(-contentHeight);
    }
}