using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    [SerializeField] private float outlineThickness = 1;
    private Material spriteMaterial;
    void Start()
    {
        spriteMaterial = new Material(GetComponent<SpriteRenderer>().material);
        GetComponent<SpriteRenderer>().material = spriteMaterial;
        spriteMaterial.SetFloat("_OutlineThickness", 0);
    }

    public void TurnOnOutline()
    {
        spriteMaterial.SetFloat("_OutlineThickness", outlineThickness);
    }
    
    public void TurnOffOutline()
    {
        spriteMaterial.SetFloat("_OutlineThickness", 0);
    }
}
