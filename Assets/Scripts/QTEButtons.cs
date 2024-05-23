using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEButtons : MonoBehaviour
{
    [SerializeField] private Sprite QLetter;
    [SerializeField] private Sprite WLetter;
    [SerializeField] private Sprite ELetter;
    [SerializeField] private Sprite RLetter;
    [SerializeField] private Sprite ALetter;
    [SerializeField] private Sprite SLetter;
    [SerializeField] private Sprite DLetter;
    [SerializeField] private Sprite FLetter;
    [SerializeField] private Sprite GLetter;

    private static Dictionary<string, int> translateLetter = new Dictionary<string, int>()
    {
        {"q",0},
        {"w",1},
        {"e",2},
        {"r",3},
        {"a",4},
        {"s",5},
        {"d",6},
        {"f",7},
        {"g",8},
    };
    
    private Sprite[] spritesLetters;
    private Image[] buttons = new Image[5];
    private int currentIndexButton = 0;
    private int[] settedLetters = new int[5];
    void Start()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            buttons[i] = transform.GetChild(i).GetComponent<Image>();
            buttons[i].color = new Color(1f, 1f, 1f, 0f); 
        }

        spritesLetters = new[] { QLetter, WLetter, ELetter, RLetter, ALetter, SLetter, DLetter, FLetter, GLetter };
    }

    public void SetButtons()
    {
        for (var i = 0; i < buttons.Length;i++)
        {
            var rnd = Random.Range(0, 8);
            buttons[i].sprite = spritesLetters[rnd];
            settedLetters[i] = rnd;
        }

        buttons[currentIndexButton].color = new Color(1f, 1f, 1f, 1f);
    }

    public bool CheckButton(string buttonLetter)
    {
        return settedLetters[currentIndexButton] == translateLetter[buttonLetter];
    }

    public void NextButton()
    {
        buttons[currentIndexButton].color = new Color(1f, 1f, 1f, 0f);
        if (currentIndexButton == buttons.Length - 1)
        {
            PentagrammController.Instance.GetQteResult(true);
            ResetQte();
        }
        else
        {
            currentIndexButton++;
            buttons[currentIndexButton].color = new Color(1f, 1f, 1f, 1f); 
        }
    }

    public void ResetQte()
    {
        buttons[currentIndexButton].color = new Color(1f, 1f, 1f, 0f);
        CustomInputInitializer.CustomInput.Global.QTE.performed -= PentagrammController.Instance.OnQtePressed;
        currentIndexButton = 0;
    }
}
