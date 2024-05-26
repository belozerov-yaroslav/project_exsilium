public class BedroomDoor : RoomDoorInteraction
{
    public override void Interact()
    {
        if (GlobalVariables.Slept)
        {
            if (GlobalVariables.MorokBanished)
            {
                if (!GlobalVariables.Slept2)
                {
                    Player.BubbleText.ShowMessage("Мне надо поспать");
                    return;
                }
            }
            else
            {
                Player.BubbleText.ShowMessage("Мне нужно изгнать дьявола");
                return;
            }
        }
        base.Interact();
    }
}