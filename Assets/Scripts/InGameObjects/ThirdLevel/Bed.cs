using GameStates;
using UnityEngine;

public class Bed : MonoBehaviour, IInteraction
{
    public void Interact()
    {
        GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
        LevelLoader.Instance.LoadLevelWithLoadingScreen("Level4");
    }
}