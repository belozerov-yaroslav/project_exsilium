public class BedroomDoor : RoomDoorInteraction
{
    public override void Interact()
    {
        if (GlobalVariables.Slept && !GlobalVariables.MorokBanished)
        {
            Player.BubbleText.ShowMessage("Мне нужно изгнать дьявола");
            return;
        }
        base.Interact();
    }
}