using System;
using UnityEngine;

public class BedAction : MonoBehaviour, IInteraction
{
    [SerializeField] private Slides _slildes;
    [SerializeField] private Material defaultMaterial;

    private void Start()
    {
        if (GlobalVariables.Slept3) gameObject.GetComponent<SpriteRenderer>().material = defaultMaterial;
    }

    public void Interact()
    {
        if (GlobalVariables.Slept)
        {
            if (GlobalVariables.MorokBanished)
            {
                if (GlobalVariables.ChertBanished && GlobalVariables.MertvyakBanished)
                {
                    RoomDoorInteraction.LastSceneName = "Sleep";
                    GlobalVariables.Slept3 = true;
                    LevelLoader.Instance.LoadLevelWithLoadingScreen("Level9");
                }
                else
                {
                    if (GlobalVariables.Slept2)
                        Player.BubbleText.ShowMessage("Мне нужно изгнать призраков в других комнатах");
                    else
                    {
                        GlobalVariables.Slept2 = true;
                        RoomDoorInteraction.LastSceneName = "Sleep";
                        LevelLoader.Instance.LoadLevelWithLoadingScreen("Level9");
                    }
                }
            }
            else
            {
                Player.BubbleText.ShowMessage("Мне нужно изгнать призрака");
            }
                
        }
        else
        {
            _slildes.ShowSlides();
            GlobalVariables.Slept = true;
            GlobalVariables.NotFirstMansion = true;
            FirstVisit.Instance.StopWorking();            
        }
    }
}