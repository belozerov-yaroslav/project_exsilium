public class BedroomDoor : RoomDoorInteraction
{
    public bool Locked;
    public override void Interact()
    {
        if (Locked)
        {
            Player.BubbleText.ShowMessage("Мне нужно изгнать дьявола");
            return;
        }
        base.Interact();
    }
}