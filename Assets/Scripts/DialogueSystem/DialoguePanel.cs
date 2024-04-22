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
    private List<GameObject> currentMessages = new List<GameObject>();
    private List<GameObject> currentChoiceButtons = new List<GameObject>();
    private float lastMessagePos = 0;
    private float contentHeight = 0;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Panel in the scene");
        }
        instance = this;
    }
    private void Start()
    {
    }
    public static DialoguePanel GetInstance() { return instance; }
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
        newTextElement.SetActive(true);
        newTextElement.transform.localPosition = new Vector3(newTextElement.transform.localPosition.x, lastMessagePos - spaceBetweenMessages, 0);

        TextMeshProUGUI textElem = newTextElement.GetComponent<TextMeshProUGUI>();
        textElem.text = message;
        lastMessagePos = newTextElement.transform.localPosition.y - textElem.GetPreferredValues().y;
        AdjustContentSize(textElem.GetPreferredValues().y + spaceBetweenMessages);

        currentMessages.Add(newTextElement);
    }
    public void DisplayChoices(List<string> choices)
    {
        int index = 0;
        foreach (string choice in choices)
        {
            GameObject choiceBtn = Instantiate(choiceBtnExample, content.transform);
            choiceBtn.SetActive(true);
            choiceBtn.transform.localPosition = new Vector3(choiceBtn.transform.localPosition.x, -contentHeight - spaceBetweenMessages, 0);

            var i = index; // c# - гений, эта строка нужна для обхода "особенностей языка", НЕ УБИРАТЬ
            choiceBtn.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(i));
            index += 1;

            TextMeshProUGUI btnText = choiceBtn.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = choice;
            float textHeight = btnText.GetPreferredValues().y;
            choiceBtn.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textHeight + 2 * btnTextMargin);
            AdjustContentSize(spaceBetweenMessages + textHeight + 2 * btnTextMargin);

            currentChoiceButtons.Add(choiceBtn);
        }
    }
    private void AdjustContentSize(float adjustSize)
    {
        contentHeight += adjustSize;
        content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, contentHeight);
    }
    public void ButtonClicked(int index)
    {
        DeleteChoiceButtons();
        DialogueManager.GetInstance().MakeChoice(index);
    }
    private void DeleteChoiceButtons()
    {
        foreach (GameObject choiceButton in currentChoiceButtons)
        {
            Destroy(choiceButton);
        }
        currentChoiceButtons.Clear();
        AdjustContentSize(-(contentHeight + lastMessagePos));
    }
    private void DeleteAllMessages()
    {
        foreach (GameObject message in currentMessages)
        {
            Destroy(message);
        }
        currentMessages.Clear();
        lastMessagePos = 0;
        AdjustContentSize(-contentHeight);
    }
}
