using System;
using UnityEngine;

public class PentagramLearning : MonoBehaviour
{
    public static PentagramLearning Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two PentagramLearning in the scene");
        Instance = this;
    }

    private void Start()
    {
        CheckLearning();
    }

    public void CheckLearning()
    {
        if (GlobalVariables.IsPentagramLearned)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
    
}