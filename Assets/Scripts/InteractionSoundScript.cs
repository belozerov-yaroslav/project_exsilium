using System.Collections;
using System.Collections.Generic;
using Inventory.Items_Classes;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractionSoundScript : MonoBehaviour
{
    public static InteractionSoundScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Find another InteractionSoundScript on the scene");
        }
        else
            Instance = this;
    }
    
    public Dictionary<ItemEnum, AudioSource> ItemSounds = new Dictionary<ItemEnum, AudioSource>();
    [SerializeField]public AudioSource pickingUpSound;
    [SerializeField] public AudioSource openDoorSound;
    [SerializeField] public AudioSource closedDoorSound;
    
    void Start()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var itemInteractionElem = transform.GetChild(i).GetComponent<ItemInteractionClass>();
            ItemSounds[itemInteractionElem.itemEnum] = itemInteractionElem.itemInteractionSound;
        }
    }

}
