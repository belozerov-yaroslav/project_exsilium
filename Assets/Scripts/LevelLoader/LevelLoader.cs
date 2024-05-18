using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1;
    [SerializeField] private Canvas crossFade;
    [SerializeField] private GameObject clickBlocker;
    public static LevelLoader Instance;
    public static bool _transitionWithLoadingScreen;
    private static readonly int Start1 = Animator.StringToHash("Start");
    private static readonly int End = Animator.StringToHash("End");

    private void Awake()
    {
        if (Instance != null)
            Debug.LogWarning("Found more than one levelLoader in the scene");
        Instance = this;
    }

    private void Start()
    {
        if (!_transitionWithLoadingScreen) return;
        StartCoroutine(FadeOut());
        _transitionWithLoadingScreen = false;
    }

    public bool IsLoad()
    {
        return crossFade.gameObject.activeSelf;
    }
    public void LoadLevelWithLoadingScreen(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
    }

    private IEnumerator FadeOut()
    {
        crossFade.gameObject.SetActive(true);
        transitionAnimator.SetTrigger(End);
        clickBlocker.SetActive(false);

        yield return new WaitForSeconds(transitionTime);

        crossFade.gameObject.SetActive(false);
    }

    private IEnumerator LoadLevel(string levelName)
    {
        _transitionWithLoadingScreen = true;
        crossFade.gameObject.SetActive(true);
        transitionAnimator.SetTrigger(Start1);
        clickBlocker.SetActive(true);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }
}