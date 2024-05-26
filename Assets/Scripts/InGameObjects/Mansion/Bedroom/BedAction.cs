using UnityEngine;

public class BedAction : MonoBehaviour, IInteraction
{
    [SerializeField] private Slides _slildes; 
    [SerializeField] private Slides _slildes2; 
    public void Interact()
    {
        if (GlobalVariables.Slept)
        {
            if (GlobalVariables.MorokBanished)
            {
                if (GlobalVariables.ChertBanished && GlobalVariables.MertvyakBanished)
                {
                    _slildes2.ShowSlides();
                    GlobalVariables.Slept2 = true;
                }
                else
                {
                    if (GlobalVariables.Slept2)
                        Player.BubbleText.ShowMessage("Мне нужно изгнать призраков в других комнатах");
                    else
                    {
                        RoomDoorInteraction.LastSceneName = "Sleep";
                        GlobalVariables.Slept2 = true;
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