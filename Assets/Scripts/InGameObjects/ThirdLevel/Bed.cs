using GameStates;
using UnityEngine;

public class Bed : MonoBehaviour, IInteraction
{
    public void Interact()
    {
        QuestMarkerManager.Instance.SetCurrentMarker("Прочитать письмо");
        GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
        LevelLoader.Instance.LoadLevelWithLoadingScreen("Level4");
    }
}