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

    private static readonly Dictionary<string, int> TranslateLetter = new Dictionary<string, int>()
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

    private const float ColorStep = 0.04f;
    private readonly Color _wrongColor = new Color(1f, 0.5f, 0.5f, 1f);
    private Sprite[] _spritesLetters;
    private readonly Image[] _buttons = new Image[5];
    private int _currentIndexButton = 0;
    private readonly int[] _setLetters = new int[5];
    void Start()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            _buttons[i] = transform.GetChild(i).GetComponent<Image>();
            _buttons[i].color = new Color(1f, 1f, 1f, 0f); 
        }

        _spritesLetters = new[] { QLetter, WLetter, ELetter, RLetter, ALetter, SLetter, DLetter, FLetter, GLetter };
    }

    public void SetButtons()
    {
        for (var i = 0; i < _buttons.Length;i++)
        {
            var rnd = Random.Range(0, 8);
            _buttons[i].sprite = _spritesLetters[rnd];
            _setLetters[i] = rnd;
        }

        _buttons[_currentIndexButton].color = new Color(1f, 1f, 1f, 1f);
    }

    public bool CheckButton(string buttonLetter)
    {
        return _setLetters[_currentIndexButton] == TranslateLetter[buttonLetter];
    }

    public void NextButton()
    {
        _buttons[_currentIndexButton].color = new Color(1f, 1f, 1f, 0f);
        if (_currentIndexButton == _buttons.Length - 1)
        {
            PentagrammController.Instance.GetQteResult(true);
            ResetQte();
        }
        else
        {
            _currentIndexButton++;
            _buttons[_currentIndexButton].color = new Color(1f, 1f, 1f, 1f); 
        }
    }

    public void WrongLetter()
    {
        if (_buttons[_currentIndexButton].color.b > 0.7f)
        {
            _buttons[_currentIndexButton].color = _wrongColor;
        }
        else
        {
            var buttonColor = _buttons[_currentIndexButton].color;
            _buttons[_currentIndexButton].color = 
                new Color(1f, buttonColor.g - ColorStep, buttonColor.b - ColorStep, 1f);
        }

    }

    public void ResetQte()
    {
        _buttons[_currentIndexButton].color = new Color(1f, 1f, 1f, 0f);
        CustomInputInitializer.CustomInput.Global.QTE.performed -= PentagrammController.Instance.OnQtePressed;
        _currentIndexButton = 0;
    }
}
